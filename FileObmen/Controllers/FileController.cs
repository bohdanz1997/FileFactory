using System;
using System.Linq;
using System.Web.Mvc;
using FileObmen.Mappers;
using FileObmen.Models;
using FileObmen.Models.ViewModels;
using FileObmen.Tools;

namespace FileObmen.Controllers
{
    public class FileController : BaseController
    {
        public FileController(UnitOfWork unit, IMapper mapper) : base (unit, mapper)
        {
        }

        [Authorize]
        public ActionResult Plupload()
        {
            var user = UnitOfWork.Users.GetUser(User.Identity.Name);
            long total = 1024 * 1024 * 1024;
            long transfered = 0;
            var persent = FileHelper.CalcFilesSize(user.Files.ToList(), total, ref transfered);
            long balance = total - transfered;
            var model = new UploadViewModel
            {
                Files = UnitOfWork.Files.Files,
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

        public FileResult GetFile(string sha)
        {
            var file = UnitOfWork.Files.GetFile(sha);
            string filePath = Server.MapPath("~/Files/" + file.Id + ".upload");
            return File(filePath, file.Type, file.Name);
        }

        [Authorize]
        public ActionResult EditFile(string sha)
        {
            if (sha == null)
                return HttpNotFound();
            var file = UnitOfWork.Files.GetFile(sha);
            if (file == null)
                return HttpNotFound();
            var model = new FileEditModel
            {
                Id = file.Id,
                Sha = file.Sha,
                Name = file.Name,
                Password = file.Password,
                DeleteTime = Convert.ToString((file.DeleteTime - file.CreationTime).Days)
            };
            return PartialView(model);
        }

        [Authorize]
        public ActionResult CheckPassword(string sha)
        {
            var file = UnitOfWork.Files.GetFile(sha);
            if (file == null)
                return HttpNotFound();
            var model = new FilePasswordModel
            {
                FilePassword = file.Password,
                Sha = file.Sha
            };
            return View(model);
        }

        public JsonResult GetFileLink(string fileNames)
        {
            if (String.IsNullOrEmpty(fileNames))
                return Json(null, JsonRequestBehavior.AllowGet);
            fileNames += ',';
            var input = DataParser.ParseLinkData(fileNames);
            var guids = input.Select(s => new GuidData
            {
                Name = s, 
                Guid = GuidEncoder.Encode(Guid.NewGuid()), 
                Url = Request.Url.Authority
            }).ToList();
            return Json(guids, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Share(string sha)
        {
            if (!String.IsNullOrEmpty(sha))
            {
                var model = new ShareModel
                {
                    Guid = sha
                };
                return PartialView(model);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Share(ShareModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var sender in model.Senders)
                {
                    if (MailSender.IsValidEmail(sender))
                        MailSender.SendMail(sender, Request.Url.Authority + "/Files/" + model.Guid);
                }
                return RedirectToAction("Details", new {sha = model.Guid});
            }
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Upload(string guidData)
        {
            var guids = DataParser.ParseGuidData(guidData);
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var upload = Request.Files[i];
                if (upload != null)
                {
                    var guid = guids.FirstOrDefault(data => data.Name == upload.FileName);
                    var user = UnitOfWork.Users.GetUser(User.Identity.Name);
                    if (user != null)
                    {
                        var file = UnitOfWork.Files.Create();
                        file.UserId = user.Id;
                        file.Name = upload.FileName;
                        file.Size = upload.ContentLength;
                        file.Type = FileHelper.GetFileType(upload.FileName);
                        file.Sha = guid.Guid;
                        file.DeleteTime = file.CreationTime.AddDays(30);
                        file.Description = FileHelper.CreateIconPath(Server, file.Type);
                        
                        UnitOfWork.Files.SaveFile(file);
                        UnitOfWork.SaveChanges();

                        upload.SaveAs(Server.MapPath("~/Files/" + file.Id + ".upload"));
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public JsonResult DelFile(string sha)
        {
            if (sha == null)
                return Json(null);

            var file = UnitOfWork.Files.GetFile(sha);
            if (file == null)
                return Json(null);
            UnitOfWork.Files.Delete(file);
            UnitOfWork.SaveChanges();

            System.IO.File.Delete(Server.MapPath("~/Files/" + file.Id + ".upload"));

            return Json(file, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditFile(FileEditModel model)
        {
            if (ModelState.IsValid)
            {
                int days = Convert.ToInt32(model.DeleteTime);
                var file = UnitOfWork.Files.GetFile(model.Id);
                if (file == null)
                    return HttpNotFound();

                ModelMapper.Map(model, file);
                file.DeleteTime = file.CreationTime.AddDays(days);
                UnitOfWork.Files.SaveFile(file);
                UnitOfWork.SaveChanges();
                
                return RedirectToAction("Details", "File", new { sha = file.Sha });
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult CheckPassword(FilePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password == model.FilePassword)
                    return RedirectToAction("ShowFile", "Home",
                        new { sha = model.Sha, acceptPass = false });
                ModelState.AddModelError("", "Неправильный пароль");
            }
            return View();
        }
        
        public ActionResult Details(string sha)
        {
            if (sha == null)
                return HttpNotFound();
            var file = UnitOfWork.Files.GetFile(sha);
            ViewBag.Url = Request.Url.Authority + "/Files/" + sha;
            return View(file);
        }
    }
}
