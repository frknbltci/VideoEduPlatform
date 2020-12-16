using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MehmetEgitKurumsal.UI.Models
{
    public class AnnouncementVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SortNumber { get; set; }
        public bool ActOrPass { get; set; }

        public string AnContent { get; set; }


    }
}