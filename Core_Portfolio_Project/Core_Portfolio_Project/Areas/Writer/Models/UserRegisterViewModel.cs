using System.ComponentModel.DataAnnotations;

namespace Core_Portfolio_Project.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adınızı Giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen  Adınızı Giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Tekrar Giriniz")]
        [Compare("Password",ErrorMessage ="Girdiğiniz Şifreler eşleşmemektedir.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lütfen Mailinizi Giriniz")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen Image Url Giriniz")]
        public string ImageUrl { get; set; }
    }
}
