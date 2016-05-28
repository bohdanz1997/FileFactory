using System.Collections.Generic;
using System.Linq;
using FileObmen.Models.Entities;

namespace FileObmen.Models.Repository
{
    public class PlanRepository : RepositoryBase<Plan>
    {
        public PlanRepository(FileObmenContext db) : base(db)
        {
        }

        public List<Plan> Plans
        {
            get { return db.Plans.ToList(); }
        }

        public Plan GetPlan(string name)
        {
            return Plans.FirstOrDefault(r => r.Name == name);
        }
    }
}