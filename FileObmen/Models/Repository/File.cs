using System.Data.Entity;
using System.Linq;
using FileObmen.Models.Entities;

namespace FileObmen.Models.Repository
{
    public partial class FileObmenRepository
    {
        public IQueryable<File> Files
        {
            get { return db.Files; }
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
                    dbEntry.Type = file.Type;
                    dbEntry.Type = file.Type;
                    dbEntry.Size = file.Size;
                    dbEntry.CreationTime = file.CreationTime;
                }
            }
            db.SaveChanges();
        }
        public File GetFile(int? fileId)
        {
            var file = db.Files.Include(f => f.User)
                .FirstOrDefault(t => t.Id == fileId);
            return file;
        }
        public File GetFile(string sha)
        {
            var file = db.Files.Include(f => f.User)
                .FirstOrDefault(t => t.Sha == sha);
            return file;
        }
        public File DeleteFile(string sha)
        {
            var dbEntry = db.Files.FirstOrDefault(f => f.Sha == sha);
            if (dbEntry != null)
            {
                db.Files.Remove(dbEntry);
                db.SaveChanges();
            }
            return dbEntry;
        }
    }
}