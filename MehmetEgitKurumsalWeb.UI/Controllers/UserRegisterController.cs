using MehmetEgitKurumsal.DAL.DB;
using MehmetEgitKurumsalWeb.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MehmetEgitKurumsalWeb.UI.Controllers
{
    public class UserRegisterController : BaseController
    {
        // GET: Register
        public ActionResult Register()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult makeRegister(UserVM gelen)
        {
            var varMi = service.UserService.GetAll().Where(x => x.Email == gelen.Email).FirstOrDefault();

            if (varMi !=null)
            {
                return Json(gelen.Email, JsonRequestBehavior.AllowGet);
            }
            else
            { 
            
            if (gelen.FirstName != null && gelen.LastName != null && gelen.Pass!=null && gelen.ConfPass != null && gelen.Email !=null && gelen.UserName != null)
            {

                if (gelen.Pass != gelen.ConfPass)
                {

                  return Json(gelen.Pass, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    User newUser = new User()
                    {
                        Email = gelen.Email,
                        BirthDate = gelen.BirhDate == DateTime.MinValue ? DateTime.UtcNow : gelen.BirhDate,
                        Phone = gelen.Phone,
                        UserName=gelen.UserName,
                        Type=false,
                        Surname=gelen.LastName,
                        Name=gelen.FirstName,
                        Status=false,
                        Password=gelen.Pass,
                        MemberShipDate=DateTime.UtcNow.Date
                    };
                    service.UserService.Insert(newUser);

                    bool gittiMi=action.SendConfirmationEmail(gelen.Email);
                    if (gittiMi==true)
                    {
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                   
                }

            }
            else
            {
                return Json(false,JsonRequestBehavior.AllowGet);
            }

            }
                       
        }

    }
}