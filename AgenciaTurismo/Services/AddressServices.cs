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
        public bool Insert(Address address)
        {
            bool status = false;

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
                commandInsert.Parameters.Add(new SqlParameter("@IdCidade", address.city.Id));

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

        public List<Address> FindAll()
        {
            List<Address> adresslist = new();
            StringBuilder sb = new StringBuilder();

            sb.Append("select e.Id,e.Logradouro,e.Numero, e.Bairro, e.CEP, e.Complemento, e.Dtcadastro, c.Id " +
                "from Endereco e, Cidade c where c.Id = e.IdCidade");

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
                    Id = (int)dr["Id"]
                };
                address.RegisterDate = (DateTime)dr["Dtcadastro"];

                adresslist.Add(address);
            }
            return adresslist;
        }
    }
}
