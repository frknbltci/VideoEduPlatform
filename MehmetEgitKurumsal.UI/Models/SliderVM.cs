using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MehmetEgitKurumsal.UI.Models
{
    public class SliderVM
    {
        public string ImgUrlOld { get; set; }
        public HttpPostedFileBase ImageUrl { get; set; }

        public string ButtonName { get; set; }
        public string Text { get; set; }

        public string Title { get; set; }
        public string Link { get; set; }

    }
}