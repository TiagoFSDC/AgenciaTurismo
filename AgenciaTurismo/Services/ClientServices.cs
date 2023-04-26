using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;
using AgenciaTurismo.Repositories;

namespace AgenciaTurismo.Services
{
    public class ClientServices
    {
        readonly string strconn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\dev-aula\AgenciaTurismo\AgenciaTurismo\docs\Scripts\AgenciaTurismo.mdf";
        readonly SqlConnection Conn;

        private IClientRepository clientRepository;

        public ClientServices()
        {
            clientRepository = new ClientRepository();
        }

        public bool InsertDapper(Client client)
        {
            return clientRepository.InsertDapper(client);
        }

        public List<Client> GetAllDapper()
        {
            return clientRepository.GetAllDapper();
        }

        public bool UpdateDapper(Client client)
        {
            return clientRepository.UpdateDapper(client);
        }

        public bool DeleteDapper(int id)
        {
            return clientRepository.DeleteDapper(id);
        }
    }
}
