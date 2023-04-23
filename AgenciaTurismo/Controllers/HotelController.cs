using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;
using AgenciaTurismo.Services;

namespace AgenciaTurismo.Controllers
{
    public class HotelController
    {
        public bool Insert(Hotel hotel)
        {
            return new HotelServices().Insert(hotel);
        }

        public List<Hotel> FindAll()
        {
            return new HotelServices().FindAll();
        }

        public bool Update(int id, string name)
        {
            return new HotelServices().Update(id, name);
        }

        public bool Delete(int id)
        {
            return new HotelServices().Delete(id);
        }
    }
}
