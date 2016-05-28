using System.Collections.Generic;
using System.Linq;
using FileObmen.Models.Entities;

namespace FileObmen.Models.Repository
{
    public class RoleRepository : RepositoryBase<Role>
    {
        public RoleRepository(FileObmenContext db) : base(db)
        {
        }

        public List<Role> Roles
        {
            get { return db.Roles.ToList(); }
        }

        public Role GetRole(string name)
        {
            var role = Roles.FirstOrDefault(r => r.Name == name);
            return role;
        }
    }
}