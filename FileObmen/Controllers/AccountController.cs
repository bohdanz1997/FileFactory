using System;
using System.IO.Compression;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using FileObmen.Mappers;
using FileObmen.Migrations;
using FileObmen.Models;
using FileObmen.Models.Entities;
using FileObmen.Models.ViewModels;
using FileObmen.Tools;

namespace FileObmen.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(UnitOfWork unit, IMapper mapper) : base(unit, mapper)
        {
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                var user = UnitOfWork.Users.Users
                    .FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);
                
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("Plupload", "File");
                }
                ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
            }

            return View(model);
        }

        public ActionResult Register()
        {
            var model = new RegisterModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var instance = UnitOfWork.Users.GetUser(model.Login);
                if (instance != null)
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                if (!MailSender.IsValidEmail(model.Email))
                    ModelState.AddModelError("", "Неправильный email");

                if (ModelState.IsValid)
                {
                    model.Role = UnitOfWork.Roles.GetRole("user");
                    var user = UnitOfWork.Users.Create();
                    ModelMapper.Map(model, user);
                    user.RegistrationDate = DateTime.Now;
                    user.AvatarPath = "photo0.png";
                    user.PlanId = 3;
                    UnitOfWork.SaveChanges();

                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
