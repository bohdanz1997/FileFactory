using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileObmen.Models.ViewModels
{
    public class AdminModel
    {
        public IEnumerable<Entities.User> Users { get; set; }
        public IEnumerable<Entities.File> Files { get; set; }
    }
}