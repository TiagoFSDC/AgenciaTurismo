using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Services
{
    public class ClientServices
    {
        readonly string strconn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\dev-aula\AgenciaTurismo\AgenciaTurismo\docs\Scripts\AgenciaTurismo.mdf";
        readonly SqlConnection Conn;

        public ClientServices()
        {
            Conn = new SqlConnection(strconn);
            Conn.Open();
        }

        public bool Insert(Client client)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Client (Name, Phone, IdEndereco) " +
                    "values (@Name, @Phone, @IdEndereco)";

                SqlCommand commandInsert = new SqlCommand(strInsert, Conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name", client.Name));
                commandInsert.Parameters.Add(new SqlParameter("@Phone", client.Phone));
                commandInsert.Parameters.Add(new SqlParameter("@IdEndereco", InsertAddress(client)));

                commandInsert.ExecuteNonQuery();
                status = true;
            }
            catch
            {
                status = false;
                throw;
            }
            finally
            {
                Conn.Close();
            }
            return status;
        }

        private int InsertAddress(Client client)
        {
            string strInsert = "insert into Endereco (Logradouro, Numero, Bairro, CEP, Complemento, IdCidade) " +
            "values (@Logradouro, @Numero, @Bairro, @CEP, @Complemento, @IdCidade); select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, Conn);

            commandInsert.Parameters.Add(new SqlParameter("@Logradouro", client.address.Street));
            commandInsert.Parameters.Add(new SqlParameter("@Numero", client.address.Number));
            commandInsert.Parameters.Add(new SqlParameter("@Bairro", client.address.District));
            commandInsert.Parameters.Add(new SqlParameter("@CEP", client.address.ZipCode));
            commandInsert.Parameters.Add(new SqlParameter("@Complemento", client.address.Complement));
            commandInsert.Parameters.Add(new SqlParameter("@IdCidade", InsertCity(client.address)));

            return (int)commandInsert.ExecuteScalar();
        }

        private int InsertCity(Address address)
        {
            string strInsert = "insert into Cidade (Descricao) values (@Descricao); select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, Conn);
            commandInsert.Parameters.Add(new SqlParameter("@Descricao", address.city.Description));

            return (int)commandInsert.ExecuteScalar();
        }

        public List<Client> FindAll()
        {
            List<Client> clientlist = new();
            StringBuilder sb = new StringBuilder();

            sb.Append("select c.Name,c.Phone,c.RegisterDate, e.Id" +
                " from Endereco e Join Client c ON e.Id = c.IdEndereco");

            SqlCommand commandSelect = new(sb.ToString(), Conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Client client = new();

                client.Id = (int)dr["Id"];
                client.Name = (string)dr["Name"];
                client.Phone = (string)dr["Phone"];
                client.address = new Address()
                {
                    Id = (int)dr["Id"],
                    //Street = (string)dr["Logradouro"],
                    //Number = (int)dr["Numero"],
                    //District = (string)dr["Bairro"],
                    ZipCode = (string)dr["CEP"],
                    Complement = (string)dr["Complemento"],
                    city = new City()
                    {
                      Id = (int)dr["Id"]
                    },
                    RegisterDate = (DateTime)dr["Dtcadastro"]

                };
                client.RegisterDate = (DateTime)dr["RegisterDate"];

                clientlist.Add(client);
            }
            return clientlist;
        }

        public bool Update(int id, string name)
        {
            bool status = false;

            try
            {
                string strUpdate = "update Client Set Name = " + "'" + name + "' where Id = " + id;

                SqlCommand commandUpdate = new SqlCommand(strUpdate, Conn);

                commandUpdate.ExecuteNonQuery();
                status = true;
            }
            catch
            {
                status = false;
                throw;
            }
            finally
            {
                Conn.Close();
            }
            return status;
        }

        public bool Delete(int id)
        {
            bool status = false;

            try
            {
                string strDelete = $"Delete from Client where Id = {id}";

                SqlCommand commandDelete = new SqlCommand(strDelete, Conn);

                commandDelete.ExecuteNonQuery();
                status = true;
            }
            catch
            {
                status = false;
                throw;
            }
            finally
            {
                Conn.Close();
            }
            return status;
        }
    }
}
