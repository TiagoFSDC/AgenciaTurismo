using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Repositories
{
    public interface IClientRepository
    {
        bool InsertDapper(Client client);

        List<Client> GetAllDapper();

        bool UpdateDapper(Client client);

        bool DeleteDapper(int Id);
    }
}
