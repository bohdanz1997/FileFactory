using System.Data.Entity;
using FileObmen.Models.Entities;

namespace FileObmen.Models.Repository
{
    public class FileObmenContext : DbContext
    {
        public FileObmenContext() :
            base("DefaultConnection")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Settings> Settings { get; set; }
    }
}