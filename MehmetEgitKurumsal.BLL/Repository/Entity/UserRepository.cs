using MehmetEgitKurumsal.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmetEgitKurumsal.BLL.Repository.Entity
{
    public class UserRepository : Base.BaseRepository<User>
    {
        public void makePassOrActive(int? id)
        {
            User user = Find((int)id);
            if (user.Status==false)
            {
                user.Status =true;
                Save();
            }
            else
            {
                user.Status = false;
                Save();
            }
        }

        public void updateUser(User gelen)
        {
            User u = Find(gelen.ID);
            u.Name = gelen.Name;
            u.UserName = gelen.UserName;
            u.Surname = gelen.Surname;
            u.Status = gelen.Status;
            u.Type = gelen.Type;
            u.Password = gelen.Password;
            u.Phone = gelen.Phone;
            u.Email = gelen.Email;
            u.Discount = gelen.Discount;
            u.BirthDate = gelen.BirthDate;
            Save();

        }

        public void updateAdmin(User gelen)
        {
            
            User u = Find(gelen.ID);
            u.Name = gelen.Name;
            u.UserName = gelen.UserName;
            u.Surname = gelen.Surname;
            u.Password = gelen.Password;
            u.Phone = gelen.Phone;
            u.Email = gelen.Email;
            u.Resume = gelen.Resume;
            u.ImageUrl = gelen.ImageUrl;
            Save();
        }

        public User FindUserName(string name)
        {
            var bul = table.FirstOrDefault(x => x.UserName == name);
            return bul;

        }

        public User FindEmail(string email)
        {
            var findEmail = table.FirstOrDefault(x => x.Email == email);

            return findEmail;
        }


    }
}
