using MehmetEgitKurumsal.UI.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MehmetEgitKurumsal.UI.Controllers
{
    public class HomeController : BaseController
    {

        [Auth]
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}