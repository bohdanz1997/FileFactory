using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileObmen.Models.ViewModels
{
    public class ShareModel
    {
        [Required]
        public List<string> Senders { get; set; }

        public string Password { get; set; }

        public string Guid { get; set; }
    }
}