using MehmetEgitKurumsal.SessionOperations;
using MehmetEgitKurumsal.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MehmetEgitKurumsal.UI.Controllers
{
    public class AdminController : BaseController
    {
        [HttpGet]
        public ActionResult Login()
        {
           
            if (((MehmetEgitKurumsal.SessionOperations.AdminSessionContext)Session["AdminSessionContext"]) == null)
            {
                return View();

            }
            else
            {
                return Redirect("/Home/Index");
            }
        
            
        }

        [HttpPost]
        public ActionResult doLogin(LoginVM gelen)
        {
            if (ModelState.IsValid)
            {
                var varMi = service.UserService.GetAll().Where(x => x.UserName == gelen.UserName && x.Password == gelen.Password).SingleOrDefault();

                var ImgUrlDefault= "/Assets/Images/noImgMan.jpg";
                if (varMi != null && varMi.Type==true)
                {
                    AdminSessionContext _adminSessionContext = new AdminSessionContext()
                    {
                        UserName = varMi.UserName, 
                        ImgPath = varMi.ImageUrl != null ? varMi.ImageUrl : ImgUrlDefault

                    };
                    Session["AdminSessionContext"] = _adminSessionContext;
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    //Admin Bulunamadı.
                    return Json("except", JsonRequestBehavior.AllowGet);
                }

            }
            else
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }

            
        }


    
        public ActionResult Logout()
        {
            Session.Abandon();
            return Redirect("/Admin/Login");
        }
    }
}