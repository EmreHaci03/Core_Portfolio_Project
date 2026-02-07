using Microsoft.AspNetCore.Identity;

namespace Core_Portfolio_Project.Areas.Writer.Models
{
    public class CustomIdentityErrorDescriber:IdentityErrorDescriber
    {

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Şifreniz en az {length} karakter içermelidir!"
            };
        }
        public override IdentityError PasswordRequiresLower() //En az 1 küçük harf içermelidir.
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = $"Şifreniz en az 1 küçük harf içermelidir!"
            };
        }
        public override IdentityError PasswordRequiresUpper()//En az 1 büyük harf içermelidir.
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = $"Şifreniz en az 1 büyük harf içermelidir!"
            };
        }

        public override IdentityError PasswordRequiresDigit() //En az 1 rakam içermektedir.
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",
                Description = $"Şifreniz en az 1 özel rakam içermektedir!"
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric() //En az 1 sembol içermektedir.
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = $"Şifreniz en az 1 sembol içermelidir!"
            };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError()
            {
                Code = "DuplicateUserName",
                Description = $"{userName} adlı kullanıcı adı zaten alınmış,farklı bir kullanıcı adı deneyin."
            };
        }
    }
}
