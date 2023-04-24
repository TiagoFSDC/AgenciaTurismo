using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;
using AgenciaTurismo.Services;
using static System.Formats.Asn1.AsnWriter;

namespace AgenciaTurismo.Controllers
{
    public class CityController
    {
        private CityServices cityService;
        public CityController()
        {
            cityService = new CityServices();
        }

        public List<City> GetAllDapper()
        {
            return cityService.GetAllDapper();
        }

        public bool InsertDapper(City city)
        {
            return cityService.InsertDapper(city);
        }

        public bool UpdateDapper(City city)
        {
            return cityService.UpdateDapper(city);
        }

        public bool DeleteDapper(City city)
        {
            return cityService.DeleteDapper(city);
        }

    }
}
