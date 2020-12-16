using MehmetEgitKurumsal.UI.Attribute;
using MehmetEgitKurumsal.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MehmetEgitKurumsal.UI.Controllers
{
    public class TeacherController : BaseController
    {

        [Auth]
        // GET: Teacher
        public ActionResult Index()
        {

            var tList = service.VideoEducationTeacherService.GetAll().ToList();

            TeacherVM data = new TeacherVM()
            {
                TeacherList = tList
            };

            return View(data);
        }


        public ActionResult editTeacher(int? ID)
        {
            if (ID != null)
            {
                var getData = service.VideoEducationTeacherService.GetAll().Where(x => x.ID == ID).SingleOrDefault();

                if (getData == null) { getData.ImgUrl = "/Assets/Images/avatar-1.png"; }

                var data = new TeacherVM()
                {
                    Address = getData.Address,
                    Description = getData.Description,
                    FacebookUrl = getData.FacebookUrl,
                    ImgUrlOld = getData.ImgUrl,
                    InstagramUrl = getData.InstagramUrl,
                    LinkedinUrl = getData.LinkedinUrl,
                    Name = getData.Name,
                    Phone = getData.Phone,
                    Surname = getData.Surname,
                    SubTitle = getData.SubTitle,
                    TwitterUrl = getData.TwitterUrl,
                    ID = (int)ID
                };

                return View(data);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }


        [HttpPost]
        public ActionResult setTeacherInfo(TeacherVM gelen)
        {
            string resimAdi;

            if (gelen.ImageUrl != null)
            {
                var file = gelen.ImageUrl;
                var uzanti = Path.GetExtension(file.FileName);
                resimAdi = "/Assets/Images/TeacherImages/" + Guid.NewGuid() + uzanti;
                file.SaveAs(Server.MapPath(resimAdi));
            }
            else
            {
                resimAdi = gelen.ImgUrlOld;
            }

            try
            {
                var UpdateData = service.VideoEducationTeacherService.Find(gelen.ID);
                UpdateData.TwitterUrl = gelen.TwitterUrl;
                UpdateData.Surname = gelen.Surname;
                UpdateData.SubTitle = gelen.SubTitle;
                UpdateData.Phone = gelen.Phone;
                UpdateData.Name = gelen.Name;
                UpdateData.InstagramUrl = gelen.InstagramUrl;
                UpdateData.LinkedinUrl = gelen.LinkedinUrl;
                UpdateData.Address = gelen.Address;
                UpdateData.Email = gelen.Email;
                UpdateData.ImgUrl = resimAdi;
                UpdateData.FacebookUrl = gelen.FacebookUrl;
                UpdateData.Description = gelen.Description;

                service.VideoEducationTeacherService.Save();

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }
    }
}
