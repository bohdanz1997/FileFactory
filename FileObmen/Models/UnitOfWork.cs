using System;
using FileObmen.Models.Repository;

namespace FileObmen.Models
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private FileObmenContext db;

        public FileRepository Files { get; }
        public UserRepository Users { get; }
        public RoleRepository Roles { get; }
        public PlanRepository Plans { get; }
        public SettingsRepository Settings { get; }

        public UnitOfWork()
        {
            db = new FileObmenContext();
            Files = new FileRepository(db);
            Users = new UserRepository(db);
            Roles = new RoleRepository(db);
            Settings = new SettingsRepository(db);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        private bool disposed;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
