using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.PortfolioValidation
{
    public class ServiceValidator:AbstractValidator<Service>
    {
        public ServiceValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Alanı Boş Geçilemez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Image Alanı Boş Geçilemez");

            RuleFor(x => x.Title).MinimumLength(10).WithMessage("Başlık 10 Karakterden Az Olamaz");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Başlık 50 Karakterden Fazla Olamaz");


            RuleFor(x => x.ImageUrl).MinimumLength(5).WithMessage("Image Url 5 Karakterden Az Olamaz");
            RuleFor(x => x.ImageUrl).MaximumLength(50).WithMessage("Image Url 50 Karakterden Fazla Olamaz");
        }
    }
}
