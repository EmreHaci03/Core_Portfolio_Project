using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.PortfolioValidation
{
    public class AboutValidator: AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Alanı Boş Geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Alanı Boş Geçilemez");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Yaş Alanı Boş Geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Alanı Boş Geçilemez");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon Alanı Boş Geçilemez");
            RuleFor(x => x.Adress).NotEmpty().WithMessage("Adres Alanı Boş Geçilemez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Image Alanı Boş Geçilemez");

            RuleFor(x => x.Description).MinimumLength(20).WithMessage("Proje Adı 20 Karakterden Fazla Olamaz");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Proje Adı 500 Karakterden Fazla Olamaz");
        }
    }
}
