using System.Web.Mvc;
using FileObmen.Mappers;
using FileObmen.Models;

namespace FileObmen.Controllers
{
    public class NavController : BaseController
    {
        public NavController(UnitOfWork unit, IMapper mapper) : base(unit, mapper)
        {
        }

        public PartialViewResult Head()
        {
            var user = UnitOfWork.Users.GetUser(User.Identity.Name);
            return PartialView(user);
        }

        public PartialViewResult Menu()
        {
            return PartialView();
        }
    }
}
