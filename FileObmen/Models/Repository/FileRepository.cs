using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FileObmen.Models.Entities;

namespace FileObmen.Models.Repository
{
    public class FileRepository : RepositoryBase<File>
    {
        public FileRepository(FileObmenContext db) : base(db)
        {
        }

        public List<File> Files
        {
            get { return db.Files
                .Include(f => f.User)
                .ToList(); }
        }

        public void SaveFile(File file)
        {
            if (file.Id == 0)
            {
                db.Files.Add(file);
            }
            else
            {
                var dbEntry = db.Files.Find(file.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = file.Name;
                    dbEntry.DeleteTime = file.DeleteTime;
                    dbEntry.Password = file.Password;
                    dbEntry.Type = file.Type;
                    dbEntry.Size = file.Size;
                    dbEntry.CreationTime = file.CreationTime;
                }
            }
        }

        public File GetFile(int? fileId)
        {
            var file = Files.FirstOrDefault(t => t.Id == fileId);
            return file;
        }

        public File GetFile(string sha)
        {
            var file = Files.FirstOrDefault(t => t.Sha == sha);
            return file;
        }

        public File DeleteFile(string sha)
        {
            var dbEntry = db.Files.FirstOrDefault(f => f.Sha == sha);
            if (dbEntry != null)
            {
                db.Files.Remove(dbEntry);
            }
            return dbEntry;
        }
    }
}