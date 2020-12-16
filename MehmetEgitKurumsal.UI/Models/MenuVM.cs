using MehmetEgitKurumsal.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MehmetEgitKurumsal.UI.Models
{
    public class MenuVM
    {

       public List<Menu> MenuList { get; set; }
        public int ID { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public int SubID { get; set; }
        public string Description { get; set; }

        public int SortNumber { get; set; }

        public bool ActOrPass { get; set; }

    }


    
}