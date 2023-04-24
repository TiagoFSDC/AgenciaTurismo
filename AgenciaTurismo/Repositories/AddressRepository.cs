using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;
using System.Data.SqlClient;
using Dapper;

namespace AgenciaTurismo.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly string _strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\dev-aula\AgenciaTurismo\AgenciaTurismo\docs\Scripts\AgenciaTurismo.mdf";

        public bool DeleteDapper(Address address)
        {
            var status = false;
            using (var db = new SqlConnection(_strConn))
            {
                db.Open();
                db.Execute(Address.DELETE, address);
                status = true;
            }

            return status;
        }

        public List<Address> GetAllDapper()
        {
            List<Address> addresslist = new();

            using (var db = new SqlConnection(_strConn))
            {
                var address = db.Query<Address>(Address.GETALL);
                addresslist = (List<Address>)address;
            }
            return addresslist;
        }

        public bool InsertDapper(Address address)
        {
            var status = false;
            using (var db = new SqlConnection(_strConn))
            {
                db.Open();
                db.Execute(Address.INSERT1, address);
                status = true;
            }
            return status;
        }

        public bool UpdateDapper(Address address)
        {
            var status = false;
            using (var db = new SqlConnection(_strConn))
            {
                db.Open();
                db.Execute(Address.UPDATE, address);
                status = true;
            }

            return status;
        }
    }
}
