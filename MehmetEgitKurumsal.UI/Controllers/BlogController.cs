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
    public class BlogController : BaseController
    {
        [Auth]

        [HttpGet]
        public ActionResult Index()
        {
            var list = service.BlogService.GetAll().OrderByDescending(x => x.ID).ToList();
            var catList = service.BlogCategoryService.GetAll().OrderBy(x => x.ID).ToList();

            var bloglist = new BlogVM()
            {
                BlogList = list,
                BlogCatList = catList
            };

            return View(bloglist);
        }

        //Blog Oluşturma Sayfası

        [HttpGet]
        [Auth]
        public ActionResult createBlog()
        {
            var blogCatList = service.BlogCategoryService.GetAll().OrderBy(x => x.ID).ToList();

            var list = new BlogVM()
            {
                BlogCatList = blogCatList
            };

            return View(list);
        }

        [HttpPost]
        public ActionResult addBlog(BlogVM gelen)
        {

            string resimAdi;

            try
            {

                var newSeoUrl = strOp.ToSlug(gelen.BlogSeoUrl);
                var varMi = service.BlogService.GetAll().Where(x => x.SeoUrl == newSeoUrl).FirstOrDefault();
                if (varMi != null) { return Json(gelen.BlogSeoUrl, JsonRequestBehavior.AllowGet); }

                if (gelen.BlogImgUrl != null)
                {
                    var file = gelen.BlogImgUrl;
                    var uzanti = Path.GetExtension(file.FileName);
                   
                    resimAdi = "/Assets/Images/BlogImages/" + Guid.NewGuid() + uzanti;
                    file.SaveAs(Server.MapPath(resimAdi));
                }
                else
                {
                    resimAdi = null;
                }

                Blog newBlog = new Blog()
                {
                    CategoryID = gelen.CategoryID,
                    SeoUrl = newSeoUrl,
                    BlogName = gelen.BlogName,
                    BlogContent = gelen.BlogContent,
                    MetaTitle = gelen.BlogMetaDesc,
                    MetaDescription = gelen.BlogMetaDesc,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    ImageUrl = resimAdi
                };
                service.BlogService.Insert(newBlog);
            }
            catch (Exception)
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]

        public ActionResult editBlog(BlogVM gelen)
        {
            string resimAdi;

            if (gelen.BlogImgUrl != null)
            {
                var file = gelen.BlogImgUrl;
                var uzanti = Path.GetExtension(file.FileName);
                resimAdi = "/Assets/Images/BlogImages/" + Guid.NewGuid() + uzanti;
                file.SaveAs(Server.MapPath(resimAdi));
            }
            else
            {
                resimAdi = gelen.strBlogImgUrl;
            }

            var newSeoUrl =strOp.ToSlug(gelen.BlogSeoUrl);
            var varMi = service.BlogService.GetAll().Where(x => x.SeoUrl == newSeoUrl).FirstOrDefault();
            if (varMi==null)
            {
                try
                {
                    var UpdateBlog = service.BlogService.Find(gelen.ID);
                    UpdateBlog.ImageUrl = resimAdi;
                    UpdateBlog.CategoryID = gelen.CategoryID;
                    UpdateBlog.BlogName = gelen.BlogName;
                    UpdateBlog.UpdatedAt = DateTime.Now.Date;
                    UpdateBlog.SeoUrl = newSeoUrl;
                    UpdateBlog.MetaDescription = gelen.BlogMetaDesc;
                    UpdateBlog.MetaTitle = gelen.BlogMetaTitle;
                    UpdateBlog.BlogContent = gelen.BlogContent;

                    service.BlogService.Save();

                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {

                    return Json(false, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                if (varMi.ID==gelen.ID)
                {
                    try
                    {
                        var UpdateBlog = service.BlogService.Find(gelen.ID);
                        UpdateBlog.ImageUrl = resimAdi;
                        UpdateBlog.CategoryID = gelen.CategoryID;
                        UpdateBlog.BlogName = gelen.BlogName;
                        UpdateBlog.UpdatedAt = DateTime.Now.Date;
                        UpdateBlog.SeoUrl = newSeoUrl;
                        UpdateBlog.MetaDescription = gelen.BlogMetaDesc;
                        UpdateBlog.MetaTitle = gelen.BlogMetaTitle;
                        UpdateBlog.BlogContent = gelen.BlogContent;

                        service.BlogService.Save();

                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception)
                    {

                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }
               
                return Json(gelen.BlogSeoUrl, JsonRequestBehavior.AllowGet);
            }

            
        }

        
        public ActionResult BlogDetail(int? ID)
        {
            if (ID != null)
            {
                var getData = service.BlogService.GetAll().Where(x => x.ID == ID).SingleOrDefault();

                var catList = service.BlogCategoryService.GetAll().ToList();

                if (getData == null) { getData.ImageUrl = "/Assets/Images/noImgMan.jpg"; }

                var blogInfo = new BlogVM()
                {
                    BlogName = getData.BlogName,
                    BlogSeoUrl = getData.SeoUrl,
                    CategoryID = (int)getData.CategoryID,
                    strBlogImgUrl = getData.ImageUrl,
                    BlogMetaDesc = getData.MetaDescription,
                    BlogMetaTitle = getData.MetaTitle,
                    BlogContent = getData.BlogContent,
                    BlogCatList = catList,
                    ID=(int)ID
                };

                return View(blogInfo);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }


      

        [HttpPost]
        public ActionResult makeActiveOrPassive(int? ID)
        {
            if (ID != null)
            {
                var makePassOrActData = service.BlogService.Find((int)ID);

                if (makePassOrActData.Status == true)
                {
                    makePassOrActData.Status = false;
                    service.BlogService.Save();
                }
                else
                {
                    makePassOrActData.Status = true;
                    service.BlogService.Save();
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