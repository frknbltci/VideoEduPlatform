using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MehmetEgitKurumsalWeb.UI.Models
{
    public class PaymentVM
    {

        public int UserID { get; set; }

        public string Email { get; set; }


        //String olarak ürün bilgisi için kullanıcaz
        public int? PacketId { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }


    }
}