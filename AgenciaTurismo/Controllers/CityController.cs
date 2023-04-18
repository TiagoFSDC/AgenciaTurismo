using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;
using AgenciaTurismo.Services;

namespace AgenciaTurismo.Controllers
{
    public class CityController
    {
        public bool Insert(City city)
        {
            return new CityServices().Insert(city);
        }

        public List<City> FindAll() 
        { 
            return new CityServices().FindAll();
        }

        public bool Update(City city, int id, string desc)
        {
            return new CityServices().Update(city, id, desc);
        }

        public bool Delete(int id)
        {
            return new CityServices().Delete(id);
        }
    }
}
