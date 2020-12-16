using MehmetEgitKurumsal.UI.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MehmetEgitKurumsal.UI.Controllers
{
    public class ContactMainController : BaseController
    {
        [Auth]
        // GET: ContactMain
        public ActionResult Index()
        {
            var contactList = service.ContactMainService.GetAll().ToList();
            return View(contactList);
        }
          public ActionResult ContactMessages()
        {
            var contactList = service.ContactService.GetAll().ToList();
            return View(contactList);
        }




    }
}