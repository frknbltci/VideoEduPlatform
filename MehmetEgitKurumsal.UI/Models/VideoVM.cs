using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MehmetEgitKurumsal.UI.Models
{
    public class VideoVM
    {

        public string VideoName { get; set; }

        public HttpPostedFileBase VideoUrl { get; set; }

        public string readVideoUrl { get; set; }

        public string VideoDesc { get; set; }

        public bool Preview { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int PacketID { get; set; }
        public int TeacherID { get; set; }

        public int MyProperty { get; set; }


    }
}