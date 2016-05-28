using System;
using System.Collections.Generic;

namespace FileObmen.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public Role Role { get; set; }
        public int? PlanId { get; set; }
        public Plan Plan { get; set; }
        public int? RoleId { get; set; }
        public Settings Settings { get; set; }
        public int? SettingsId { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<File> Files { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string AvatarPath { get; set; }

        public User()
        {
            Files = new List<File>();
        }
    }
}