using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;
using Dapper;
using static System.Formats.Asn1.AsnWriter;

namespace Repositories
{
    public class CityRepository : ITourAgencyRepository
    {
        private string Conn { get; set; }

        public CityRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString; //String conexão
        }

        public List<City> GetAll()
        {
            using (var db = new SqlConnection(Conn))
            {
                var stores = db.Query<City>(City.GETALL);
                return (List<City>)stores;
            }
        }

        public bool Insert(City city)
        {
            var status = false;
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                db.Execute(City.INSERT, city);
                status = true;
            }

            return status;
        }
    }
}
