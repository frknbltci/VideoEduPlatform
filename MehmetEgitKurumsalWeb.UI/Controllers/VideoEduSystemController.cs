using MehmetEgitKurumsal.DAL.DB;
using MehmetEgitKurumsalWeb.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MehmetEgitKurumsalWeb.UI.Controllers
{
    public class VideoEduSystemController : BaseController
    {

        [HttpGet]
       
        public ActionResult Index()
        {

            //Patlarsa act eklendi 9/8/20
            var list = service.PacketService.GetAll().Where(x=>x.ActOrPass==true).ToList();
            var purchlist = service.PurchaseService.GetAll().ToList();

            var plist = new PacketVM()
            {
                PacketList = list,
                PurchaseList=purchlist

            };

            return View(plist);
        }

        
        [Route("egitimler/{SeoUrlLink}")]
        public ActionResult Details(string SeoUrlLink)
        {

            var educate = service.PacketService.GetAll().Where(x => x.SeoUrlLink == SeoUrlLink).FirstOrDefault();

            if (SeoUrlLink == null || educate==null)
            {
                ViewBag.yok = "Sayfa Bulunamadı";
                return View();
            }
            else
            {
                
                var videos = service.VideoService.GetAll().Where(x => x.PacketID == educate.ID).OrderByDescending(x => x.Preview == true).ToList();

           

                int bosID;
                if (((MehmetEgitKurumsal.SessionOperations.UserSessionContext)Session["UserSessionContext"]) == null)
                {
                    bosID = 0;
                }
                else
                {
                    bosID = (int)((MehmetEgitKurumsal.SessionOperations.UserSessionContext)Session["UserSessionContext"]).ID;
                }

             
                var list = new PacketDetailVM()
                {
                    VideoList = videos,
                    Packet = educate,
                    UserID = bosID,
                    isPurch = service.PurchaseService.GetAll().Where(x => x.PacketID == educate.ID && x.UserID == bosID).SingleOrDefault()

                };

                return View(list);
            }


        }



        [HttpPost]
        public ActionResult getVideo(int? ID, int? PID)
        {
            if (PID == null) { PID = 0; }
            if (ID == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                int bosID;
                if (((MehmetEgitKurumsal.SessionOperations.UserSessionContext)Session["UserSessionContext"]) == null)
                {
                    bosID = 0;
                }
                else
                {
                    bosID = (int)((MehmetEgitKurumsal.SessionOperations.UserSessionContext)Session["UserSessionContext"]).ID;
                }
                var vUrl = service.VideoService.Find((int)ID);
                var varMi = service.PurchaseService.GetAll().Where(x => x.UserID == bosID && x.PacketID == PID).FirstOrDefault();
                if (varMi != null)
                {


                    return Json(vUrl.VideoUrl, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (vUrl.Preview == true)
                    {
                        return Json(vUrl.VideoUrl, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }


                }

            }

        }

    }
}