using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MehmetEgitKurumsalWeb.UI.Models
{
    public class ContactMainVM
    {
        //Hem anasayfa hemde iletişim sayfası için kullanılmıştır
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Message { get; set; }

        public string Topic { get; set; }

        public DateTime CreatedAt { get; set; }
       
    }
}