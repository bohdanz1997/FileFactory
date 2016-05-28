using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FileObmen.Models.Entities;

namespace FileObmen.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        [DisplayName("Логин")]
        public string Login { get; set; }

        [Required]
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [DisplayName("Логин")]
        public string Login { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DisplayName("Подтвердите пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("Возраст")]
        public int Age { get; set; }

        public Role Role { get; set; }
    }
}