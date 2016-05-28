using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileObmen.Mappers;
using FileObmen.Models;
using FileObmen.Models.Entities;
using FileObmen.Models.ViewModels;
using PagedList;

namespace FileObmen.Controllers
{
    public class AdminController : BaseController
    {
        public AdminController(UnitOfWork unit, IMapper mapper) : base(unit, mapper)
        {
        }

        public ActionResult Files(int? page)
        {
            var files = UnitOfWork.Files.Files;
            files.Reverse();
            return View(files.ToPagedList(page ?? 1, 10));
        }

        public ActionResult Users(int? page)
        {
            var users = UnitOfWork.Users.Users;
            return View(users.ToPagedList(page ?? 1, 10));
        }

        public ActionResult Stats()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public JsonResult DelUser(int? id)
        {
            if (id == null)
                return Json(null);
            var user = UnitOfWork.Users.GetUser(id);
            if (user == null)
                return Json(null);
            UnitOfWork.Users.Delete(user);
            UnitOfWork.SaveChanges();

            return Json(user, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DemoteUser(int? id)
        {
            if (id == null)
                return Json(null);
            var user = UnitOfWork.Users.GetUser(id);
            if (user == null)
                return Json(null);
            user.RoleId = 2;
            UnitOfWork.Users.SaveUser(user);
            UnitOfWork.SaveChanges();

            return Json(user, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PromoteUser(int? id)
        {
            if (id == null)
                return Json(null);
            var user = UnitOfWork.Users.GetUser(id);
            if (user == null)
                return Json(null);
            user.RoleId = 1;
            UnitOfWork.Users.SaveUser(user);
            UnitOfWork.SaveChanges();

            return Json(user, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult Search(string data)
        {
            var result = UnitOfWork.Files.Files.Where(f => f.Name.Contains(data)).ToList();
            return PartialView("SearchData", result);
        }
    }
}
