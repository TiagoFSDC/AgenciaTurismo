using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;
using AgenciaTurismo.Services;

namespace AgenciaTurismo.Controllers
{
    internal class ClientController
    {
        public bool Insert(Client client)
        { 
            return new ClientServices().Insert(client);
        }

        public List<Client> FindAll()
        {
            return new ClientServices().FindAll();
        }

        public bool Update(int id, string name)
        {
            return new ClientServices().Update(id, name);
        }

        public bool Delete(int id)
        {
            return new ClientServices().Delete(id);
        }
    }
}
