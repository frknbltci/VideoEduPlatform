using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MehmetEgitKurumsal.UI.Models
{
    public class PacketVM
    {

        public int ID { get; set; }
        public int hiddenPacketId { get; set; }
        public string PackageName { get; set; }
        public string PacketDesc { get; set; }
        public string hiddenOldImg { get; set; }
        public string SeoUrlLink { get; set; }
        public double PacketPrice { get; set; }

        public HttpPostedFileBase PacketImgUrl { get; set; }



    }
}