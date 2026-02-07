using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.PortfolioValidation
{
    public class FeatureValidator: AbstractValidator<Feature>
    {
        public FeatureValidator()
        {
            RuleFor(x => x.Header).NotEmpty().WithMessage("Başlık Alanı Boş Geçilemez");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Alanı Boş Geçilemez");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Ünvan Alanı Boş Geçilemez");

            RuleFor(x => x.Header).MaximumLength(20).WithMessage("Proje Adı 40 Karakterden Fazla Olamaz");

            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Proje Adı 40 Karakterden Fazla Olamaz");

            RuleFor(x => x.Title).MinimumLength(10).WithMessage("Proje Adı 10 Karakterden Az Olamaz");
            RuleFor(x => x.Title).MaximumLength(90).WithMessage("Proje Adı 90 Karakterden Fazla Olamaz");
        }
    }
}
