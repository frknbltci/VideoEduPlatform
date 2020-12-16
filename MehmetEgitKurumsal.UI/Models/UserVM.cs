using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MehmetEgitKurumsal.UI.Models
{
    public class UserVM
    {

        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Resume { get; set; }
        public string ImageUrl { get; set; }
        public DateTime MemberShipDate { get; set; }


        public HttpPostedFileBase file { get; set; }

        public string hiddenImage { get; set; }

        public int hiddenId { get; set; }
      

        public string sMemberShipDate { get; set; }
       
        public DateTime BirthDate { get; set; }

        public string sBirthDate { get; set; }

        public string MailKey { get; set; }

        public bool Type { get; set; }

        public Nullable<double> Discount { get; set; }

        public bool Status { get; set; }



    }
}