using System;
using System.Web.Mvc;
using FileObmen.Mappers;
using FileObmen.Models;
using FileObmen.Tools;

namespace FileObmen.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(UnitOfWork unit, IMapper mapper) : base (unit, mapper)
        {
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            return View(User.Identity.IsAuthenticated);
        }
        
        public ActionResult ShowFile(string sha, bool acceptPass = true)
        {
            if (sha == null)
                return HttpNotFound();
            var file = UnitOfWork.Files.GetFile(sha);
            var user = UnitOfWork.Users.GetUser(User.Identity.Name);
            if (user != null && user.Role.Name == "admin")
                return View(file);
            if (file.Password != null && acceptPass)
                return RedirectToAction("CheckPassword", "File", new {sha});
            return View(file);
        }
        
    }
}
