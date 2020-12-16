using MehmetEgitKurumsal.DAL.DB;
using MehmetEgitKurumsal.UI.Attribute;
using MehmetEgitKurumsal.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MehmetEgitKurumsal.UI.Controllers
{
    public class PageController : BaseController
    {
        [Auth]
        // GET: Page
        public ActionResult Index()
        {
            var lst = service.PageService.GetAll().ToList();

            var dataList = new PageVM()
            {
                PageList = lst
            };

            return View(dataList);
        }


        public ActionResult EditPage(int? ID)
        {
            if (ID != null)
            {
                var getData = service.PageService.GetAll().Where(x => x.ID == ID).SingleOrDefault();

                if (getData == null) { getData.ImgUrl = "/Assets/Images/noImgMan.jpg"; }

                var pageInfo = new PageVM()
                {
                    PageName = getData.Title,
                    PageSeoUrl = getData.SeoUrl,
                    CategoryID = (int)getData.Category,
                    strImgUrl = getData.ImgUrl,
                    PageMetaDesc = getData.MetaDescription,
                    PageContent = getData.Text,
                    PageMetaTitle = getData.MetaTitle,
                    ID = (int)ID
                };

                return View(pageInfo);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult editInfo(PageVM gelen)
        {
            string resimAdi;

            if (gelen.ImgUrl != null)
            {
                var file = gelen.ImgUrl;
                var uzanti = Path.GetExtension(file.FileName);
                resimAdi = "/Assets/Images/PageImages/" + Guid.NewGuid() + uzanti;
                file.SaveAs(Server.MapPath(resimAdi));
            }
            else
            {
                resimAdi = gelen.strImgUrl;
            }

            var newSeoUrl = strOp.ToSlug(gelen.PageSeoUrl);
            var varMi = service.PageService.GetAll().Where(x => x.SeoUrl == newSeoUrl).FirstOrDefault();
            if (varMi == null)
            {
                try
                {
                    var UpdatePage = service.PageService.Find(gelen.ID);
                    UpdatePage.ImgUrl = resimAdi;
                    UpdatePage.Category = gelen.CategoryID;
                    UpdatePage.Title = gelen.PageName;
                    UpdatePage.UpdatedAt = DateTime.Now.Date;
                    UpdatePage.SeoUrl = newSeoUrl;
                    UpdatePage.MetaDescription = gelen.PageMetaDesc;
                    UpdatePage.MetaTitle = gelen.PageMetaTitle;
                    UpdatePage.Text = gelen.PageContent;

                    service.PageService.Save();

                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {

                    return Json(false, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                if (varMi.ID == gelen.ID)
                {
                    try
                    {
                        var UpdatePage = service.PageService.Find(gelen.ID);
                        UpdatePage.ImgUrl = resimAdi;
                        UpdatePage.Category = gelen.CategoryID;
                        UpdatePage.Title = gelen.PageName;
                        UpdatePage.UpdatedAt = DateTime.Now.Date;
                        UpdatePage.SeoUrl = newSeoUrl;
                        UpdatePage.MetaDescription = gelen.PageMetaDesc;
                        UpdatePage.MetaTitle = gelen.PageMetaTitle;
                        UpdatePage.Text = gelen.PageContent;

                        service.PageService.Save();

                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception)
                    {

                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }

                return Json(gelen.PageSeoUrl, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult createPage()
        {

            return View();
        }


        [HttpPost]
        public ActionResult cPage(PageVM gelen)
        {
            string resimAdi;

            try
            {
                var newSeoUrl = strOp.ToSlug(gelen.PageSeoUrl);
                var varMi = service.PageService.GetAll().Where(x => x.SeoUrl == newSeoUrl).FirstOrDefault();
                if (varMi != null) { return Json(gelen.PageSeoUrl, JsonRequestBehavior.AllowGet); }

                if (gelen.ImgUrl != null)
                {
                    var file = gelen.ImgUrl;
                    var uzanti = Path.GetExtension(file.FileName);
                    resimAdi = "/Assets/Images/PageImages/" + Guid.NewGuid() + uzanti;
                    file.SaveAs(Server.MapPath(resimAdi));
                }
                else
                {
                    resimAdi = null;
                }


                Page newPage = new Page()
                {
                    Category = gelen.CategoryID,
                    SeoUrl = newSeoUrl,
                    Title = gelen.PageName,
                    Text = gelen.PageContent,
                    MetaTitle = gelen.PageMetaTitle,
                    MetaDescription = gelen.PageMetaDesc,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    ImgUrl = resimAdi
                };
                service.PageService.Insert(newPage);
            }
            catch (Exception)
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult makeActiveOrPassive(int? ID)
        {
            if (ID != null)
            {
                var makePassOrActData = service.PageService.Find((int)ID);

                if (makePassOrActData.Status == true)
                {
                    makePassOrActData.Status = false;
                    service.PageService.Save();
                }
                else
                {
                    makePassOrActData.Status = true;
                    service.PageService.Save();
                }

                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);

            }
        }
    }

}




