using MehmetEgitKurumsal.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MehmetEgitKurumsal.UI.Models
{
    public class TeacherVM
    {

        public int ID  { get; set; }
        public List<VideoEducationTeacher> TeacherList { get; set; }
        public string ImgUrlOld { get; set; }
        public HttpPostedFileBase ImageUrl { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string LinkedinUrl { get; set; }

        public string Address { get; set; }
       
        public string Phone { get; set; }
        public string Email { get; set; }


    }
}