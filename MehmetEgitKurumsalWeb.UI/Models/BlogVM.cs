using MehmetEgitKurumsal.DAL.DB;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MehmetEgitKurumsalWeb.UI.Models
{
    public class BlogVM
    {
        public IPagedList<Blog> BlogList { get; set; }



        public Blog BlogDetail { get; set; }

    }
}