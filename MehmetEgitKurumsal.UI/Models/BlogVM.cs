using MehmetEgitKurumsal.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MehmetEgitKurumsal.UI.Models
{
    public class BlogVM
    {
        public List<BlogCategory> BlogCatList { get; set; }

        public List<Blog> BlogList { get; set; }

        public int ID { get; set; }

        public HttpPostedFileBase BlogImgUrl { get; set; }
        public string strBlogImgUrl { get; set; }
        public string BlogName { get; set; }
        public string BlogSeoUrl { get; set; }
        public string BlogMetaTitle { get; set; }
        public string BlogMetaDesc { get; set; }
        public int CategoryID { get; set; }

        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [AllowHtml]
        public string BlogContent { get; set; }



    }
}