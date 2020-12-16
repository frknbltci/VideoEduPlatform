using MehmetEgitKurumsal.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmetEgitKurumsal.SessionOperations
{
    public class UserSessionContext
    {
        public string Email { get; set; }
        public string UserName { get; set; }

        public int? ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

    }
}
