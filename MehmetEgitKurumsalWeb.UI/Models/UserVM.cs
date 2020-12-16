using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MehmetEgitKurumsalWeb.UI.Models
{
    public class UserVM
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pass { get; set; }
        public string Phone { get; set; }
        public DateTime BirhDate { get; set; }
        
        public string ConfPass { get; set; }





    }
}