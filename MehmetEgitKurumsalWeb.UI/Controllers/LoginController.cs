using MehmetEgitKurumsal.SessionOperations;
using MehmetEgitKurumsalWeb.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MehmetEgitKurumsalWeb.UI.Controllers
{
    public class LoginController : BaseController
    {
        [HttpPost]
        public ActionResult Login(LoginVM gelen)
        {

            if (ModelState.IsValid)
            {
                var varMi = service.UserService.GetAll().Where(x => x.Email == gelen.loginEmail && x.Password == gelen.loginPass).FirstOrDefault();

                if (varMi !=null)
                {
                    if (varMi.Status==true && varMi.Type==false)
                    {

                        UserSessionContext _userSessionContext = new UserSessionContext()
                        {
                            UserName = varMi.UserName,
                            Email=varMi.Email,
                            ID=varMi.ID,
                            Name=varMi.Name,
                            Surname=varMi.Surname
                        };

                        Session["UserSessionContext"] = _userSessionContext;
                        return Json("dd", JsonRequestBehavior.AllowGet);
                   
                    }
                    else
                    {
                        return Json("aktifErr", JsonRequestBehavior.AllowGet);
                    }
                    
                }
                else
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
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
            return Redirect("/Home/Index");
        }
    }
}