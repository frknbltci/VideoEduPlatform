using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MehmetEgitKurumsal.UI.Models
{
    public class GeneralSettingsVM
    {

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Addres { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string YoutubeUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string GoogleMapsCode { get; set; }
        public int UserCount { get; set; }
        public int WatchHour { get; set; }
        public int EducationVideoCount { get; set; }

        public string FooterNote { get; set; }
       
        

        public string LogoUrlOld { get; set; }
        public HttpPostedFileBase  LogoUrl { get; set; }
    }
}