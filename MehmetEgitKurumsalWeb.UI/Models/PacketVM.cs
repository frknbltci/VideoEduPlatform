using MehmetEgitKurumsal.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MehmetEgitKurumsalWeb.UI.Models
{
    public class PacketVM
    {
        public List<Packet> PacketList { get; set; }

        public List<Purchase> PurchaseList { get; set; }

    }
}