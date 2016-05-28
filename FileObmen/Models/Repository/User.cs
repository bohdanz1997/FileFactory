using System.Data.Entity;
using System.Linq;
using FileObmen.Models.Entities;

namespace FileObmen.Models.Repository
{
    public partial class FileObmenRepository
    {
        public IQueryable<User> Users
        {
            get { return db.Users; }
        }

        public void SaveUser(User user)
        {
            if (user.Id == 0)
            {
                db.Users.Add(user);
            }
            else
            {
                var dbEntry = db.Users.Find(user.Id);
                if (dbEntry != null)
                {
                    dbEntry.Login = user.Login;
                    dbEntry.Email = user.Email;
                    dbEntry.Password = user.Password;
                    dbEntry.Age = user.Age;
                    dbEntry.RegistrationDate = user.RegistrationDate;
                }
            }
            db.SaveChanges();
        }
        public User GetUser(string name)
        {
            var users = db.Users.Include(u => u.Files).ToList();
            var user = users.FirstOrDefault(u => u.Login == name);
            return user;
        }
        public User DeleteUser(string name)
        {
            var dbEntry = db.Users.FirstOrDefault(u => u.Login == name);
            if (dbEntry != null)
            {
                db.Users.Remove(dbEntry);
                db.SaveChanges();
            }
            return dbEntry;
        }
    }
}