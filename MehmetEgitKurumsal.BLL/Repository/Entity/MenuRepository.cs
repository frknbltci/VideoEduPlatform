using MehmetEgitKurumsal.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehmetEgitKurumsal.BLL.Repository.Entity
{
    public class MenuRepository : Base.BaseRepository<Menu>
    {

        public void makePassOrActive(int? ID)
        {
            var menu = Find((int)ID);

            if (menu.ActOrPass == true) 
            {
                menu.ActOrPass = false;
            }
            else
            {
                menu.ActOrPass = true;
            }
            Save();

        }




    }
}
