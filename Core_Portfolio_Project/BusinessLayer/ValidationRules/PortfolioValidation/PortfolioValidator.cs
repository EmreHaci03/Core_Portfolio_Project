using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.PortfolioValidation
{
    public class PortfolioValidator:AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Proje Adı Boş Geçilemez");
            RuleFor(x=>x.ImageUrl).NotEmpty().WithMessage("Resim 1 Boş Geçilemez");
            RuleFor(x => x.ImageUrl2).NotEmpty().WithMessage("Resim 2 Boş Geçilemez");
            RuleFor(x => x.ProjectUrl).NotEmpty().WithMessage("Proje Linki Boş Geçilemez");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat  Boş Geçilemez");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Tamamlanma Oranı Boş Geçilemez");


            RuleFor(x => x.Name).MinimumLength(10).WithMessage("Proje Adı 10 Karakterden Az Olamaz");
            RuleFor(x => x.Name).MaximumLength(60).WithMessage("Proje Adı 60 Karakterden Fazla Olamaz");

            RuleFor(x => x.ImageUrl).MinimumLength(10).WithMessage("Proje Resim 1 10 Karakterden Az Olamaz");
            RuleFor(x => x.ImageUrl).MaximumLength(70).WithMessage("Proje Resim 1 70 Karakterden Fazla Olamaz");

            RuleFor(x => x.ImageUrl2).MinimumLength(10).WithMessage("Proje Resim 2 10 Karakterden Az Olamaz");
            RuleFor(x => x.ImageUrl2).MaximumLength(70).WithMessage("Proje Resim 2 70 Karakterden Az Olamaz");

            RuleFor(x => x.ProjectUrl).MinimumLength(10).WithMessage("Proje Linki 10 Karakterden Az Olamaz");
            RuleFor(x => x.ProjectUrl).MaximumLength(70).WithMessage("Proje Linki 70 Karakterden Fazla Olamaz");





        }
    }
}
