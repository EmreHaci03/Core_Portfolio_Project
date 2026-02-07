using Core_Proje_Api.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje_Api.DAL.Context
{
    public class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-125B7F2\\SQLEXPRESS;Database=CoreProjectApiDB;Integrated Security=True;TrustServerCertificate=True;");
        }

        public DbSet<Category> Categories { get; set; }

    }
}
