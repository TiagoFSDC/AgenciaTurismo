using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Repositories
{
    public interface IAddressRepository
    {
        bool InsertDapper(Address address);

        List<Address> GetAllDapper();

        bool UpdateDapper(Address address);

        bool DeleteDapper(Address address);
    }
}
