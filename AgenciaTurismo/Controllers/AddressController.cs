using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;
using AgenciaTurismo.Services;

namespace AgenciaTurismo.Controllers
{
    public class AddressController
    {
        public Address Insert(Address address)
        {
            return new AddressServices().Insert(address);
        }

        public List<Address> FindAll()
        {
            return new AddressServices().FindAll();
        }

        public bool Update(Address address, int id, string desc)
        {
            return new AddressServices().Update(address, id, desc);
        }

        public bool Delete(int id)
        {
            return new AddressServices().Delete(id);
        }
    }
}
