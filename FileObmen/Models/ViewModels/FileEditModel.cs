using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FileObmen.Models.ViewModels
{
    public class FileEditModel
    {
        public int Id { get; set; }
        public string Sha { get; set; }

        [Required]
        [DisplayName("Имя")]
        public string Name { get; set; }

        [DisplayName("Пароль")]
        public string Password { get; set; }

        [DisplayName("Срок хранения")]
        public string DeleteTime { get; set; }

        [DisplayName("Email адреса на которые нужно отправить ссылку (через запятую)")]
        public string Emailes { get; set; }
    }
}