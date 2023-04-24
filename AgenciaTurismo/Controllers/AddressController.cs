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
        private AddressServices addressService;

        public AddressController()
        {
            addressService = new AddressServices();
        }

        public List<Address> GetAllDapper()
        {
            return addressService.GetAllDapper();
        }

        public bool InsertDapper(Address address)
        {
            return addressService.InsertDapper(address);
        }

        public bool UpdateDapper(Address address)
        {
            return addressService.UpdateDapper(address);
        }

        public bool DeleteDapper(Address address)
        {
            return addressService.DeleteDapper(address);
        }
    }
}
