using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using FileObmen.Mappers;
using FileObmen.Models;
using FileObmen.Models.ViewModels;
using FileObmen.Tools;
using PagedList;
using WebGrease.Css.Extensions;

namespace FileObmen.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        public ProfileController(UnitOfWork unit, IMapper mapper) : base(unit, mapper)
        {
        }

        public ActionResult Index()
        {
            var user = UnitOfWork.Users.GetUser(User.Identity.Name);
            long total = user.Plan.Storage*1024;
            long transfered = 0;
            var persent = FileHelper.CalcFilesSize(user.Files.ToList(), total, ref transfered);
            var balance = total - transfered;
            var model = new UserDataViewModel
            {
                User = user,
                UserPlan = new UserPlanModel
                {
                    Total = total,
                    Percent = persent,
                    Balance = balance,
                    Transfered = transfered
                }
            };
            return View(model);
        }

        public ActionResult FilesUploaded(int? page)
        {
            var files = UnitOfWork.Users.GetUser(User.Identity.Name).Files.Reverse();
            return View(files.ToPagedList(page ?? 1, 10));
        }

        public ActionResult UserInfo()
        {
            var user = UnitOfWork.Users.GetUser(User.Identity.Name);
            if (user == null)
                return HttpNotFound();
            return View(user);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        public FileResult GetImage(int userId)
        {
            var user = UnitOfWork.Users.GetUser(userId);
            if (user != null)
            {
                if (string.IsNullOrEmpty(user.AvatarPath))
                {
                    user.AvatarPath = "photo0.png";
                    UnitOfWork.SaveChanges();
                }
                return File(Server.MapPath("~/Content/avatars/" + user.AvatarPath), "img");
            }
            return null;
        }

        public ActionResult SetAvatar()
        {
            return View(GetAvatars());
        }

        public ActionResult EditProfile()
        {
            var user = UnitOfWork.Users.GetUser(User.Identity.Name);
            var model = new ProfileEditModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Age = user.Age
            };
            
            return PartialView(model);
        }

        public ActionResult EditPlan()
        {
            //var user = UnitOfWork.Users.GetUser(User.Identity.Name);

            return View();
        }

        [HttpPost]
        public ActionResult EditProfile(ProfileEditModel model)
        {
            if (ModelState.IsValid)
            {
                var user = UnitOfWork.Users.GetUser(User.Identity.Name);
                ModelMapper.Map(model, user);
                UnitOfWork.Users.SaveUser(user);
                UnitOfWork.SaveChanges();
                return RedirectToAction("UserInfo");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SetAvatar(string hiddenField)
        {
            if (hiddenField != null && !string.IsNullOrEmpty(hiddenField))
            {
                var user = UnitOfWork.Users.GetUser(User.Identity.Name);
                user.AvatarPath = hiddenField;
                UnitOfWork.SaveChanges();
                return RedirectToAction("UserInfo");
            }
            return View(GetAvatars());
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePassModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                var user = UnitOfWork.Users.Users.FirstOrDefault(u => u.Password == model.OldPassword);
                
                if (user != null)
                {
                    if (model.OldPassword == user.Password)
                    {
                        user.Password = model.NewPassword;
                        UnitOfWork.Users.SaveUser(user);
                        UnitOfWork.SaveChanges();
                        
                        return RedirectToAction("UserInfo");
                    }
                    ModelState.AddModelError("", "Введен неправильный текущий пароль");
                }
            }
            return View();
        }

        private FileInfo[] GetAvatars()
        {
            var dir = new DirectoryInfo(Server.MapPath("~/Content/avatars/"));
            return dir.GetFiles();
        }

        public JsonResult GetUserFiles()
        {
            var userFiles = UnitOfWork.Users.GetUser(User.Identity.Name).Files;
            var list = userFiles.Select(file => new {Size = file.Size/1024, file.CreationTime.Day}).ToArray();
            var data = new int[31];
            for (int i = 0; i < data.Length; i++)
            {
                int i2 = i;
                var temp = list.Where(arg => arg.Day == i + 1).Select(arg => arg.Size).ToArray();
                temp.ForEach(i1 => data[i2] += i1);
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllFiles()
        {
            var files = UnitOfWork.Files.Files;
            var list = files.Select(file => new { Size = file.Size / 1024, file.CreationTime.Day }).ToArray();
            var data = new int[31];
            for (int i = 0; i < data.Length; i++)
            {
                int i2 = i;
                var temp = list.Where(arg => arg.Day == i + 1).Select(arg => arg.Size).ToArray();
                temp.ForEach(i1 => data[i2] += i1);
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUsersRating()
        {
            var list = UnitOfWork.Users.Users
                .Select(user => new { Name = user.Login, Size = user.Files.Sum(file => file.Size/1024/1024)})
                .OrderByDescending(arg => arg.Size).Take(5).ToArray();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
