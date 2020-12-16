using MehmetEgitKurumsal.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MehmetEgitKurumsal.UI.Models
{
    public class PageVM
    {
        public List<Page> PageList { get; set; }


        public int ID { get; set; }
        public HttpPostedFileBase ImgUrl { get; set; }
        public string strImgUrl { get; set; }

        public string PageName { get; set; }
        public string PageSeoUrl { get; set; }
        public string PageMetaTitle { get; set; }
        public string PageMetaDesc { get; set; }
        public int CategoryID { get; set; }


        [AllowHtml]
        public string PageContent { get; set; }

    }
}