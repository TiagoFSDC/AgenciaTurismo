using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;
using AgenciaTurismo.Repositories;

namespace AgenciaTurismo.Services
{
    public class AddressServices
    {
        readonly string strconn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\dev-aula\AgenciaTurismo\AgenciaTurismo\docs\Scripts\AgenciaTurismo.mdf";
        readonly SqlConnection Conn;

        private IAddressRepository addressRepository;

        public AddressServices()
        {
            addressRepository = new AddressRepository();
        }

        public bool InsertDapper(Address Address)
        {
            return addressRepository.InsertDapper(Address);
        }

        public List<Address> GetAllDapper()
        {
            return addressRepository.GetAllDapper();
        }

        public bool UpdateDapper(Address Address)
        {
            return addressRepository.UpdateDapper(Address);
        }

        public bool DeleteDapper(Address Address)
        {
            return addressRepository.DeleteDapper(Address);
        }
    }
}
