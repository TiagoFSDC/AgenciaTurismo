using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Services
{
    public class HotelServices
    {
        readonly string strconn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\dev-aula\AgenciaTurismo\AgenciaTurismo\docs\Scripts\AgenciaTurismo.mdf";
        readonly SqlConnection Conn;

        public HotelServices()
        {
            Conn = new SqlConnection(strconn);
            Conn.Open();
        }

        public bool Insert(Hotel hotel)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Hotel (Name, IdAddress, Price) " +
                    "values (@Name, @IdAddress, @Price)";

                SqlCommand commandInsert = new SqlCommand(strInsert, Conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name", hotel.Name));
                commandInsert.Parameters.Add(new SqlParameter("@IdAddress", InsertAddress(hotel)));
                commandInsert.Parameters.Add(new SqlParameter("@Price", hotel.Price));

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

        private int InsertAddress(Hotel hotel)
        {
            string strInsert = "insert into Endereco (Logradouro, Numero, Bairro, CEP, Complemento, IdCidade) " +
            "values (@Logradouro, @Numero, @Bairro, @CEP, @Complemento, @IdCidade); select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, Conn);

            commandInsert.Parameters.Add(new SqlParameter("@Logradouro", hotel.address.Street));
            commandInsert.Parameters.Add(new SqlParameter("@Numero", hotel.address.Number));
            commandInsert.Parameters.Add(new SqlParameter("@Bairro", hotel.address.District));
            commandInsert.Parameters.Add(new SqlParameter("@CEP", hotel.address.ZipCode));
            commandInsert.Parameters.Add(new SqlParameter("@Complemento", hotel.address.Complement));
            commandInsert.Parameters.Add(new SqlParameter("@IdCidade", InsertCity(hotel.address)));

            return (int)commandInsert.ExecuteScalar();
        }

        private int InsertCity(Address address)
        {
            string strInsert = "insert into Cidade (Descricao) values (@Descricao); select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, Conn);
            commandInsert.Parameters.Add(new SqlParameter("@Descricao", address.city.Description));

            return (int)commandInsert.ExecuteScalar();
        }

        //public List<Hotel> FindAll()
        //{
        //    List<Client> clientlist = new();
        //    StringBuilder sb = new StringBuilder();

        //    sb.Append("select c.Name,c.Phone,c.RegisterDate, e.Id" +
        //        " from Endereco e, Client c where e.Id = c.IdEndereco");

        //    SqlCommand commandSelect = new(sb.ToString(), Conn);
        //    SqlDataReader dr = commandSelect.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        Client client = new();

        //        client.Id = (int)dr["Id"];
        //        client.Name = (string)dr["Name"];
        //        client.Phone = (string)dr["Phone"];
        //        client.address = new Address()
        //        {
        //            Id = (int)dr["Id"],
        //            //Street = (string)dr["Logradouro"],
        //            //Number = (int)dr["Numero"],
        //            //District = (string)dr["Bairro"],
        //            //ZipCode = (string)dr["CEP"],
        //            //Complement = (string)dr["Complemento"],
        //            city = new City()
        //            {
        //                Id = (int)dr["Id"]
        //            },
        //            //RegisterDate = (DateTime)dr["Dtcadastro"]

        //        };
        //        client.RegisterDate = (DateTime)dr["RegisterDate"];

        //        clientlist.Add(client);
        //    }
        //    return clientlist;
        //}

        public bool Update(int id, string name)
        {
            bool status = false;

            try
            {
                string strUpdate = "update Hotel Set Name = " + "'" + name + "' where Id = " + id;

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
                string strDelete = $"Delete from Hotel where Id = {id}";

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
