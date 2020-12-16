using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MehmetEgitKurumsalWeb.UI.Controllers
{
    public class AccountController : BaseController
    {
     

        
        public ActionResult Verify(string Id)
        {
            

            if (Id==null)
            {
                ViewBag.nereye = 2;
                ViewBag.SuccessMessage = "<p style='color:red'>Aktivasyon Başarısız ! Sistemde kayıtlı key bulunamadı</p>";
                return View();

            }
            {
                var bulunan = service.UserService.GetAll().Where(x => x.MailKey == Id).FirstOrDefault();
                if (bulunan != null)
                {
                    bulunan.Status = true;
                    service.UserService.Save();
                    ViewBag.nereye = 1;
                    ViewBag.SuccessMessage = "<p style='color:green'>Aktivasyon Başarılı!</p>";
                    return View();
                }
                else
                {
                    ViewBag.nereye = 2;
                    ViewBag.SuccessMessage = "<p style='color:red'>Aktivasyon Başarısız ! Sistemde kayıtlı kullancı bulunamadı</p>";
                    return View();
                }
            }

      
        }
    }
}