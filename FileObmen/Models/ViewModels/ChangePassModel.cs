using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FileObmen.Models.ViewModels
{
    public class ChangePassModel
    {
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Старый пароль")]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Новый пароль")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Подтвердите пароль")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}