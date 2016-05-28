using System.Collections.Generic;
using System.Linq;
using FileObmen.Models.Entities;

namespace FileObmen.Models.Repository
{
    public class SettingsRepository : RepositoryBase<Settings>
    {
        public SettingsRepository(FileObmenContext db) : base(db)
        {
        }

        public List<Settings> Settings
        {
            get { return db.Settings.ToList(); }
        }
    }
}