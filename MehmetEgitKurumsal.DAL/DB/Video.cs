//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MehmetEgitKurumsal.DAL.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Video
    {
        public int ID { get; set; }
        public string VideoName { get; set; }
        public string VideoUrl { get; set; }
        public string VideoDescription { get; set; }
        public Nullable<bool> Preview { get; set; }
        public Nullable<System.DateTime> UpdateAt { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<int> PacketID { get; set; }
        public Nullable<int> TeacherID { get; set; }
        public Nullable<System.TimeSpan> VideoLength { get; set; }
    
        public virtual Packet Packet { get; set; }
        public virtual VideoEducationTeacher VideoEducationTeacher { get; set; }
    }
}
