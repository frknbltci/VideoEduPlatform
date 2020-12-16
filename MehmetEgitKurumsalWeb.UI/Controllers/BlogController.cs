using MehmetEgitKurumsalWeb.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace MehmetEgitKurumsalWeb.UI.Controllers
{
    public class BlogController : BaseController
    {
        // GET: Blog
        [Route("Blog/{sayfa}")]
        public ActionResult Index(int sayfa=1)
        {
            var list = service.BlogService.GetAll().OrderByDescending(x => x.ID).ToList().ToPagedList(sayfa,9);

            var plist = new BlogVM()
            {
                BlogList = list

            };

            return View(plist);
        
        }


        [Route("bloglar/{SeoUrl}")]
        public ActionResult Details(string SeoUrl)
        {

            var blogInfo = service.BlogService.GetAll().Where(x => x.SeoUrl == SeoUrl).FirstOrDefault();


            if (blogInfo == null)
            {
                ViewBag.yok = "Sayfa Bulunamadı";
                return View();
            }
            else
            {
                ViewBag.yok = null;
                var list = new BlogVM()
                {
                    BlogDetail=blogInfo

                };

                return View(list);
            }

        }

    }
}
