using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Repositories
{
    public interface ITourAgencyRepository
    {
        bool InsertDapper(City city);

        List<City> GetAllDapper();
    }
}
