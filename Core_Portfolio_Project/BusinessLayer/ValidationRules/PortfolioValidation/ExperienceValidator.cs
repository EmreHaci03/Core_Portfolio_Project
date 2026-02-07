using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.PortfolioValidation
{
    public class ExperienceValidator:AbstractValidator<Experience>
    {
        public ExperienceValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Alanı Boş Bırakılamaz.");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih Alanı Boş Bırakılamaz.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Image Alanı Boş Bırakılamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Alanı Boş Bırakılamaz.");


            RuleFor(x => x.Name).MinimumLength(10).WithMessage("Ad Alanı En az 10 karakter olmalıdır.");
            RuleFor(x => x.Name).MaximumLength(40).WithMessage("Ad Alanı En fazla 40 karakter olmalıdır.");

            RuleFor(x => x.Date).MinimumLength(5).WithMessage("Tarih Alanı En az 5 karakter olmalıdır.");
            RuleFor(x => x.Date).MaximumLength(30).WithMessage("Tarih Alanı En fazla 30 karakter olmalıdır.");

            RuleFor(x => x.ImageUrl).MinimumLength(10).WithMessage("Image Url Alanı En az 10 karakter olmalıdır.");
            RuleFor(x => x.ImageUrl).MaximumLength(60).WithMessage("Image Url Alanı En fazla 60 karakter olmalıdır.");

            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Açıklama Alanı En az 10 karakter olmalıdır.");
            RuleFor(x => x.Description).MaximumLength(100).WithMessage("Açıklama Alanı En fazla 100 karakter olmalıdır.");
        }
    }
}
