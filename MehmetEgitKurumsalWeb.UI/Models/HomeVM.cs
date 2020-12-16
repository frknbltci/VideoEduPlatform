using MehmetEgitKurumsal.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MehmetEgitKurumsalWeb.UI.Models
{
    public class HomeVM
    {

        
        public List<Blog> BlogList { get; set; }
        public List<Blog> tarihList { get; set; }
        public List<Blog> cografyaList { get; set; }

        public GeneralSetting GeneralSettings { get; set; }
        public List<Menu> MenuList { get; set; }
        public List<Announcement> AnnouncementList { get; set; }

        public List<VideoEducationTeacher> TeacherList { get; set; }
        public List<Page> BilgiSayfalariList { get; set; }
        
        public List<Page> SistemBilgiList { get; set; }
        

        public Slider Slider { get; set; }

    }
}