using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;
using AgenciaTurismo.Services;

namespace AgenciaTurismo.Controllers
{
    public class PacketController
    {
        public bool Insert(Packet packet)
        {
            return new PacketServices().Insert(packet);
        }

        //public List<City> FindAll()
        //{
        //    //return new PacketServices().FindAll();
        //}

        public bool Update(int id, double desc)
        {
            return new PacketServices().Update(id, desc);
        }

        public bool Delete(int id)
        {
            return new PacketServices().Delete(id);
        }
    }
}
