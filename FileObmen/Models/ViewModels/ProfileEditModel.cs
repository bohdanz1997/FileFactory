using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FileObmen.Models.Entities;

namespace FileObmen.Models.ViewModels
{
    public class ProfileEditModel
    {
        [Required]
        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DisplayName("Возраст")]
        public int Age { get; set; }
    }

    public class UserPlanModel
    {
        public long Total { get; set; }
        public long Transfered { get; set; }
        public string Percent { get; set; }
        public long Balance { get; set; }
    }

    public class UserDataViewModel
    {
        public User User { get; set; }
        public UserPlanModel UserPlan { get; set; }
    }

    public class UploadViewModel
    {
        public IEnumerable<File> Files { get; set; }
        public UserPlanModel UserPlan { get; set; }
    }
}