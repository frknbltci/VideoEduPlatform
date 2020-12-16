using MehmetEgitKurumsal.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MehmetEgitKurumsalWeb.UI.Models
{

    //for GeneralSettings
    public class LayoutVM
    {
        public string Name { get; set; }
        public GeneralSetting GeneralSettings { get; set; }

    }

    public class MenuVM
    {

        public string LogoUrl { get; set; }
        public List<Menu> MenuList { get; set; }

    }


    public class FooterVM
    {
        public GeneralSetting GeneralSettings { get; set; }

        public List<Page> InfoPage { get; set; }

        public List<Packet> PacketList { get; set; }

        public List<Blog> BlogList { get; set; }

        


        // Footer'ın Diğer Bilgileri Yazılacak // Video Eğitim Paketleri Vs

    }


}