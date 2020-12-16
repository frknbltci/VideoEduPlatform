using MehmetEgitKurumsal.DAL.DB;
using MehmetEgitKurumsalWeb.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MehmetEgitKurumsalWeb.UI.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Contact
        public ActionResult Index()
        {
            var data = service.GeneralSettingsService.GetAll().FirstOrDefault();

            return View(data);
        }

        [HttpPost]
        public ActionResult sendContactInfo(ContactMainVM gelen)
        {
            try
            {
                var newData = new Contact()
                {
                    CreatedAt = DateTime.Now.Date,
                    Email = gelen.Email,
                    Topic = gelen.Topic,
                    Phone = gelen.Phone,
                    NameSurname = gelen.NameSurname,
                    Message = gelen.Message
                };

                service.ContactService.Insert(newData);
                service.ContactService.Save();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {


                return Json(false, JsonRequestBehavior.AllowGet);
            }
          
        }
        
    }
}