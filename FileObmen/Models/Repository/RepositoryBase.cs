using System.Data;
using System.Data.Entity;

namespace FileObmen.Models.Repository
{
    public class RepositoryBase<T> where T : class
    {
        protected FileObmenContext db;
        protected DbSet<T> EntitySet; 

        public RepositoryBase(FileObmenContext db)
        {
            this.db = db;
            EntitySet = db.Set<T>();
        }

        public virtual T Create()
        {
            var entity = EntitySet.Create();
            EntitySet.Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
        }
    }
}