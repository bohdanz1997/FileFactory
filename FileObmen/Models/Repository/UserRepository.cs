using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FileObmen.Models.Entities;

namespace FileObmen.Models.Repository
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository(FileObmenContext db) : base(db)
        {
        }

        public List<User> Users
        {
            get { return db.Users
                .Include(u => u.Files)
                .Include(r => r.Role)
                .Include(p => p.Plan)
                .ToList(); }
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
        }

        public User GetUser(string name)
        {
            var users = Users;
            var user = users.FirstOrDefault(u => u.Login == name);
            return user;
        }

        public User GetUser(int? id)
        {
            var users = Users;
            var user = users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public User DeleteUser(string name)
        {
            var dbEntry = db.Users.FirstOrDefault(u => u.Login == name);
            if (dbEntry != null)
            {
                db.Users.Remove(dbEntry);
            }
            return dbEntry;
        }
    }
}