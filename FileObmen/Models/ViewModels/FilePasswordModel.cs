using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FileObmen.Models.ViewModels
{
    public class FilePasswordModel
    {
        [Required]
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string FilePassword { get; set; }
        public string Sha { get; set; }
    }
}