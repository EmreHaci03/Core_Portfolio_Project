using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.PortfolioValidation;
using Core_Portfolio_Project.Areas.Writer.Models;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Core_Portfolio_Project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // DbContext
            services.AddDbContext<Context>(options =>
            options.UseSqlServer("Server=DESKTOP-125B7F2\\SQLEXPRESS;Database=CoreProjectDB;Integrated Security=True;TrustServerCertificate=True;"));



            services.AddIdentity<WriterUser, WriterRole>()
            .AddEntityFrameworkStores<Context>()
            .AddDefaultTokenProviders()
            .AddErrorDescriber<CustomIdentityErrorDescriber>();

            // Cookie Authentication
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Writer/Login/Index";
                options.AccessDeniedPath = "/ErrorPage/Index";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(80);
                options.SlidingExpiration = true;
                options.Cookie.HttpOnly = true;
            });

            // Global Authorize
            services.AddControllersWithViews(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<PortfolioValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<ServiceValidator>();
            });

            // Scoped Services
            services.AddScoped<IFeatureDal, EfFeatureDal>();
            services.AddScoped<FeatureManager>();

            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<AboutManager>();

            services.AddScoped<IServiceDal, EfServiceDal>();
            services.AddScoped<ServiceManager>();

            services.AddScoped<ISkillDal, EfSkillDal>();
            services.AddScoped<SkillManager>();

            services.AddScoped<IPortfolioDal, EfPortfolioDal>();
            services.AddScoped<PortfolioManager>();

            services.AddScoped<IExperienceDal, EfExperienceDal>();
            services.AddScoped<ExperienceManager>();

            services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            services.AddScoped<TestimonialManager>();

            services.AddScoped<IMessageDal, EfMessageDal>();
            services.AddScoped<MessageManager>();

            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<ContactManager>();

            services.AddScoped<ITodoListDal, EfTodoListDal>();
            services.AddScoped<TodoListManager>();

            services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
            services.AddScoped<AnnouncemenetManager>();

            services.AddScoped<IWriterMessageDal, EfWriterMessageDal>();
            services.AddScoped<WriterMessageManager>();

            services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
            services.AddScoped<SocialMediaManager>();

            services.AddScoped<IWriterUserDal, EfWriterUserDal>();
            services.AddScoped<WriterUserManager>();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // 🔹 Middleware sırası kritik
            app.UseAuthentication(); // önce authentication
            app.UseAuthorization();  // sonra authorization

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}");
            });
        }
    }
}
