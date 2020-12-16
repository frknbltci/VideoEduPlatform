using MehmetEgitKurumsal.DAL.DB;
using MehmetEgitKurumsalWeb.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MehmetEgitKurumsalWeb.UI.Controllers
{
    public class PartialController : BaseController
    {
        // GET: Partial
       
        public ActionResult Social()
        {
            var generalSet = service.GeneralSettingsService.GetAll().FirstOrDefault();

            string name;
            if (((MehmetEgitKurumsal.SessionOperations.UserSessionContext)Session["UserSessionContext"]) == null)
            {
                name = null;
            }
            else
            {
                name= ((MehmetEgitKurumsal.SessionOperations.UserSessionContext)Session["UserSessionContext"]).UserName;
            }

            var VmList = new LayoutVM()
            {
                GeneralSettings = generalSet,
                Name=name
                

            };
            return Json(VmList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Menu()
        {
            var menuList = service.MenuService.GetAll().Where(x => x.ActOrPass == true).OrderBy(x => x.SortNumber).ToList();

            var log = service.GeneralSettingsService.GetAll().FirstOrDefault().LogoUrl;

            var mList = new MenuVM()
            {
                
                MenuList = menuList,
                LogoUrl = log

            };
            return Json(mList, JsonRequestBehavior.AllowGet);
        
        }

        [HttpGet]
        public ActionResult FooterMenu()
        {
  

            var infoPages = service.PageService.GetAll().Where(x => x.Category == 1).OrderByDescending(x => x.ID).Take(5).ToList();

            var genSet = service.GeneralSettingsService.GetAll().FirstOrDefault();


            var footData = new FooterVM()
            {
                
                GeneralSettings =genSet,
                InfoPage=infoPages,
                
                
            };
            
            return Json(footData,JsonRequestBehavior.AllowGet);

        }


    }
}