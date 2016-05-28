using System;

namespace FileObmen.Models.Entities
{
    public class File
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public User User { get; set; }
        public int? UserId { get; set; }
        public string Sha { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime DeleteTime { get; set; }

        public File()
        {
            CreationTime = DateTime.Now;
            DeleteTime = CreationTime;
        }
    }
}