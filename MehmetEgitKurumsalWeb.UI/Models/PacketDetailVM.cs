using MehmetEgitKurumsal.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MehmetEgitKurumsalWeb.UI.Models
{
    public class PacketDetailVM
    {
        public Packet Packet { get; set; }  //İlgili Paket

        public List<Video> VideoList { get; set; } 

        public VideoEducationTeacher Teacher { get; set; }
        public Purchase Purchase { get; set; }

        public Purchase isPurch { get; set; }
        public int UserID { get; set; }



    }
}