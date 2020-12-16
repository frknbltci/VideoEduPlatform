using MehmetEgitKurumsal.DAL.DB;
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
    public class SettingsController : BaseController
    {
        [Auth]
        [HttpGet]
        public ActionResult Announcement()
        {
            var announList = service.AnnouncementService.GetAll().ToList();

            return View(announList);
        }

        [Auth]
        [HttpGet]
        public ActionResult Menu()
        {

            var menuList = service.MenuService.GetAll().ToList();

            var MenuList = new MenuVM()
            {
                MenuList = menuList
            };


            return View(MenuList);
        }

        [Auth]
        [HttpGet]
        public ActionResult GeneralSettings()
        {
            var generalData = service.GeneralSettingsService.GetAll().SingleOrDefault();
            return View(generalData);

        }

        [HttpGet]

        public ActionResult Slider()
        {
           var a= service.SliderService.GetAll().FirstOrDefault();

            return View(a);
        }

        [HttpPost]
        public ActionResult editSlider(SliderVM gelen)
        {
            string resimAdi = null;
            if (gelen.ImageUrl != null)
            {
                var file = gelen.ImageUrl;
                var uzanti = Path.GetExtension(file.FileName);
                resimAdi = "/Assets/Images/" + Guid.NewGuid() + uzanti;
                file.SaveAs(Server.MapPath(resimAdi));

            }
            else
            {
                resimAdi = gelen.ImgUrlOld;
            }

            try
            {
                var updateData = service.SliderService.GetAll().FirstOrDefault();
                updateData.Title = gelen.Title;
                updateData.Text = gelen.Text;
                updateData.Link = gelen.Link;
                updateData.ImageUrl = resimAdi;
                updateData.ButtonName = gelen.ButtonName;
                service.SliderService.Save();
            }
            catch (Exception)
            {

                return Json(false, JsonRequestBehavior.AllowGet);

            }



            return Json(true, JsonRequestBehavior.AllowGet);
        }


        
        

        [HttpPost]
        public ActionResult makeMenuPassOrAct(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return Json(ID, JsonRequestBehavior.AllowGet);
            }
            else
            {
                service.MenuService.makePassOrActive(ID);
                return Json(true, JsonRequestBehavior.AllowGet);

            }
        }


        [HttpPost]
        public ActionResult getMenuInfo(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var info = service.MenuService.GetAll().Where(x => x.ID == ID).FirstOrDefault();

                if (info != null)
                {
                    return Json(info, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    return Json(false, JsonRequestBehavior.AllowGet);

                }



            }
        }


        [HttpPost]
        public ActionResult editMenu(MenuVM gelen)
        {
          
            if (gelen.Title != null)
            {
                var editData = service.MenuService.Find(gelen.ID);
                editData.Title = gelen.Title;
                editData.Link = gelen.Link;
                editData.SortNumber = gelen.SortNumber;
                editData.Description = gelen.Description;
                service.MenuService.Save();

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }
       
        
        [HttpPost]
        public ActionResult addMenu(MenuVM gelen)
        {

            if (gelen.Title !=null && gelen.SortNumber!=0)
            {
                var addData = new Menu()
                {
                    Title = gelen.Title,
                    ActOrPass = gelen.ActOrPass,
                    Description = gelen.Description,
                    Link = gelen.Link,
                    SortNumber = gelen.SortNumber,
                    SubID = 0

                };

                service.MenuService.Insert(addData);
                return Json(true, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpPost]
        public ActionResult getAnnounInfo(int? ID)
        {

            if (ID == null || ID == 0)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var info = service.AnnouncementService.GetAll().Where(x => x.ID == ID).FirstOrDefault();

                if (info != null)
                {
                    return Json(info, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    return Json(false, JsonRequestBehavior.AllowGet);

                }

            }
        }


        [HttpPost]
        public ActionResult editAnnounInfo(AnnouncementVM gelen)
        {

            if (gelen.Title != null)
            {
                var editData = service.AnnouncementService.Find(gelen.ID);
                editData.Title = gelen.Title;
                editData.SortNumber = gelen.SortNumber;
                editData.Description = gelen.Description;
                editData.AnContent = gelen.AnContent;
                service.AnnouncementService.Save();

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }
            
        
        [HttpPost]
        public ActionResult addAnnounInfo(AnnouncementVM gelen)
        {

            if (gelen.Title != null)
            {
                var addData = new Announcement()
                {
                    Description = gelen.Description,
                    SortNumber = gelen.SortNumber,
                    Title = gelen.Title,
                    ActOrPass=gelen.ActOrPass,
                    AnContent=gelen.AnContent
                };

                service.AnnouncementService.Insert(addData);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpPost]
        public ActionResult makeAnnPassOrAct(int? ID)
        {
            if (ID==0 || ID ==null)
            {
                return Json(ID, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var actOrpassData = service.AnnouncementService.GetAll().Where(x => x.ID == ID).FirstOrDefault();
                if (actOrpassData.ActOrPass == true)
                {
                    actOrpassData.ActOrPass = false;
                }
                else
                {
                    actOrpassData.ActOrPass = true;
                }
                service.AnnouncementService.Save();
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            
        }

        [HttpPost]


        public ActionResult editGeneralSettings(GeneralSettingsVM gelen)
        {

            string resimAdi = null;
            if (gelen.LogoUrl !=null)
            {
                var file = gelen.LogoUrl;    
                var uzanti = Path.GetExtension(file.FileName);
                resimAdi = "/Assets/Images/" + Guid.NewGuid() + uzanti;
                file.SaveAs(Server.MapPath(resimAdi));
               
            }
            else
            {
                resimAdi = gelen.LogoUrlOld;
            }

            try
            {
                var updateData = service.GeneralSettingsService.GetAll().FirstOrDefault();
                updateData.WatchHour = gelen.WatchHour;
                updateData.UserCount = gelen.UserCount;
                updateData.TwitterUrl = gelen.TwitterUrl;
                updateData.Phone = gelen.Phone;
                updateData.MetaTitle = gelen.MetaTitle;
                updateData.MetaDescription = gelen.MetaDescription;
                updateData.LogoUrl = resimAdi;
                updateData.InstagramUrl = gelen.InstagramUrl;
                updateData.GoogleMapsCode = gelen.GoogleMapsCode;
                updateData.FooterNote = gelen.FooterNote;
                updateData.FacebookUrl = gelen.FacebookUrl;
                updateData.Email = gelen.Email;
                updateData.EducationVideoCount = gelen.EducationVideoCount;
                updateData.Address = gelen.Addres;
                updateData.YoutubeUrl = gelen.YoutubeUrl;
                service.GeneralSettingsService.Save();

            }
            catch (Exception )
            {
                
                return Json(false, JsonRequestBehavior.AllowGet);

            }
            


            return Json(true, JsonRequestBehavior.AllowGet);
        }



    }
}