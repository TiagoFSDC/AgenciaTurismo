using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Services
{
    public class AddressServices
    {
        readonly string strconn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\dev-aula\AgenciaTurismo\AgenciaTurismo\docs\Scripts\AgenciaTurismo.mdf";
        readonly SqlConnection Conn;

        public AddressServices()
        {
            Conn = new SqlConnection(strconn);
            Conn.Open();
        }
        public Address Insert(Address address)
        {
            bool status = false;
            int id = 0;

            try
            {
                string strInsert = "insert into Endereco (Logradouro, Numero, Bairro, CEP, Complemento, IdCidade) " +
                    "values (@Logradouro, @Numero, @Bairro, @CEP, @Complemento, @IdCidade)";

                SqlCommand commandInsert = new SqlCommand(strInsert, Conn);

                commandInsert.Parameters.Add(new SqlParameter("@Logradouro", address.Street));
                commandInsert.Parameters.Add(new SqlParameter("@Numero", address.Number));
                commandInsert.Parameters.Add(new SqlParameter("@Bairro", address.District));
                commandInsert.Parameters.Add(new SqlParameter("@CEP", address.ZipCode));
                commandInsert.Parameters.Add(new SqlParameter("@Complemento", address.Complement));
                commandInsert.Parameters.Add(new SqlParameter("@IdCidade", InsertCity(address)));

                id = (int)commandInsert.ExecuteNonQuery();
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
            address.Id = id;
            return address;
        }

        private int InsertCity(Address address)
        {
            string strInsert = "insert into Cidade (Descricao) values (@Descricao); select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, Conn);
            commandInsert.Parameters.Add(new SqlParameter("@Descricao", address.city.Description));

            return (int)commandInsert.ExecuteScalar();
        }

        public List<Address> FindAll()
        {
            List<Address> adresslist = new();
            StringBuilder sb = new StringBuilder();

            sb.Append("select e.Id,e.Logradouro,e.Numero, e.Bairro, e.CEP, e.Complemento, e.Dtcadastro as dataendereço, c.Id as Cidade, c.Descricao, c.Dtcadastro as data" +
                "  from Endereco e Join Cidade c ON c.Id = e.IdCidade");

            SqlCommand commandSelect = new(sb.ToString(), Conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Address address = new();

                address.Id = (int)dr["Id"];
                address.Street = (string)dr["Logradouro"];
                address.Number = (int)dr["Numero"];
                address.District = (string)dr["Bairro"];
                address.ZipCode = (string)dr["CEP"];
                address.Complement = (string)dr["Complemento"];
                address.city = new City()
                {
                    Id = (int)dr["Cidade"],
                    Description = (string)dr["Descricao"],
                    RegisterDate = (DateTime)dr["data"]
                };
                address.RegisterDate = (DateTime)dr["dataendereço"];

                adresslist.Add(address);
            }
            return adresslist;
        }

        public bool Update(Address address,int id, string logradouro)
        {
            bool status = false;

            try
            {
                string strUpdate = "update Endereco Set Logradouro = " + "'" + logradouro + "' where Id = " + id;

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
                string strDelete = $"Delete from Endereco where Id = {id}";

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
