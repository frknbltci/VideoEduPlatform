using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MehmetEgitKurumsalWeb.UI.Controllers
{
    public class ReturnValController : Controller
    {
        // GET: ReturnVal
        public ActionResult ErrReturn()
        {
            return View();
        }

        public ActionResult SucReturn()
        {
            return View();
        }
    }
}