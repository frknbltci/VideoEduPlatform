using MehmetEgitKurumsalWeb.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MehmetEgitKurumsalWeb.UI.Controllers
{
    public class PageController : BaseController
    {
        // GET: Page
        [Route("{SeoUrl}")]
        public ActionResult Details(string SeoUrl)
        {
                
                var pageInfo = service.PageService.GetAll().Where(x => x.SeoUrl == SeoUrl).FirstOrDefault();

            if (pageInfo==null)
            {
                ViewBag.yok = "Sayfa Bulunamadı";
                return View();
            }
            else
            {
                ViewBag.yok = null;
                var list = new PageVM()
                {
                    PageDetail = pageInfo

                };

                return View(list);
            }

        }

    }
}