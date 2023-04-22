using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Services
{
    public class TicketServices
    {
        readonly string strconn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\dev-aula\AgenciaTurismo\AgenciaTurismo\docs\Scripts\AgenciaTurismo.mdf";
        readonly SqlConnection Conn;

        public TicketServices()
        {
            Conn = new SqlConnection(strconn);
            Conn.Open();
        }

        public bool Insert(Ticket ticket)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Ticket (StartId, DestinationId,ClientId, Price) " +
                    "values (@StartId, @DestinationId, @ClientId, @Price)";

                SqlCommand commandInsert = new SqlCommand(strInsert, Conn);

                commandInsert.Parameters.Add(new SqlParameter("@StartId", InsertAddressS(ticket)));
                commandInsert.Parameters.Add(new SqlParameter("@DestinationId", InsertAddressD(ticket)));
                commandInsert.Parameters.Add(new SqlParameter("@ClientId", InsertClient(ticket)));
                commandInsert.Parameters.Add(new SqlParameter("@Price", ticket.Price));

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

        private int InsertClient(Ticket ticket)
        {
            string strInsert = "insert into Client (Name, Phone, IdEndereco) "
                + "values (@Name, @Phone, @IdEndereco); select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, Conn);

            commandInsert.Parameters.Add(new SqlParameter("@Name", ticket.client.Name));
            commandInsert.Parameters.Add(new SqlParameter("@Phone", ticket.client.Phone));
            commandInsert.Parameters.Add(new SqlParameter("@IdEndereco", InsertAddressS(ticket)));

            return (int)commandInsert.ExecuteScalar();
        }

        private int InsertAddressS(Ticket ticket)
        {
            string strInsert = "insert into Endereco (Logradouro, Numero, Bairro, CEP, Complemento, IdCidade) " +
            "values (@Logradouro, @Numero, @Bairro, @CEP, @Complemento, @IdCidade); select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, Conn);

            commandInsert.Parameters.Add(new SqlParameter("@Logradouro", ticket.Start.Street));
            commandInsert.Parameters.Add(new SqlParameter("@Numero", ticket.Start.Number));
            commandInsert.Parameters.Add(new SqlParameter("@Bairro", ticket.Start.District));
            commandInsert.Parameters.Add(new SqlParameter("@CEP", ticket.Start.ZipCode));
            commandInsert.Parameters.Add(new SqlParameter("@Complemento", ticket.Start.Complement));
            commandInsert.Parameters.Add(new SqlParameter("@IdCidade", InsertCity(ticket.Start)));

            return (int)commandInsert.ExecuteScalar();
        }

        private int InsertAddressD(Ticket ticket)
        {
            string strInsert = "insert into Endereco (Logradouro, Numero, Bairro, CEP, Complemento, IdCidade) " +
            "values (@Logradouro, @Numero, @Bairro, @CEP, @Complemento, @IdCidade); select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, Conn);

            commandInsert.Parameters.Add(new SqlParameter("@Logradouro", ticket.Destination.Street));
            commandInsert.Parameters.Add(new SqlParameter("@Numero", ticket.Destination.Number));
            commandInsert.Parameters.Add(new SqlParameter("@Bairro", ticket.Destination.District));
            commandInsert.Parameters.Add(new SqlParameter("@CEP", ticket.Destination.ZipCode));
            commandInsert.Parameters.Add(new SqlParameter("@Complemento", ticket.Destination.Complement));
            commandInsert.Parameters.Add(new SqlParameter("@IdCidade", InsertCity(ticket.Destination)));

            return (int)commandInsert.ExecuteScalar();
        }
        private int InsertCity(Address address)
        {
            string strInsert = "insert into Cidade (Descricao) values (@Descricao); select cast(scope_identity() as int)";
            SqlCommand commandInsert = new SqlCommand(strInsert, Conn);
            commandInsert.Parameters.Add(new SqlParameter("@Descricao", address.city.Description));

            return (int)commandInsert.ExecuteScalar();
        }

        public List<Ticket> FindAll()
        {
            List<Ticket> ticketlist = new();
            StringBuilder sb = new StringBuilder();

            sb.Append("t.Id, eST.Id, eST.Logradouro," +
                " eST.Numero, eST.Bairro, eST.CEP, eST.Complemento, eST.DtCadastro,eDT.Id, eDT.Logradouro," +
                " eDt.Numero, eDT.Bairro, eDT.CEP, eDT.Complemento, eDT.DtCadastro,  " +
                " cid.Id, cid.Descricao, cid.DtCadastro as data," +
                " cid2.Id, cid2.Descricao, cid2.DtCadastro as data" +
                " from Ticket"+
                " Join " +
                " Join Endereco e ON h.IdAddress = e.Id" +
                " Join Cidade as cid ON cid.Id = e.IdCidade");

            SqlCommand commandSelect = new(sb.ToString(), Conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Ticket ticket = new();

                ticket.Id = (int)dr["Id"];
                ticket.Start = new Address()
                {
                    Id = (int)dr["Id"],
                    Street = (string)dr["Logradouro"],
                    Number = (int)dr["Numero"],
                    District = (string)dr["Bairro"],
                    ZipCode = (string)dr["CEP"],
                    Complement = (string)dr["Complemento"],
                    city = new City()
                    {
                        Id = (int)dr["Cidade"],
                        Description = (string)dr["Descricao"],
                        RegisterDate = (DateTime)dr["data"]
                    },
                    RegisterDate = (DateTime)dr["dataendereço"]
                };

                ticket.Destination = new Address()
                {
                    Id = (int)dr["Id"],
                    Street = (string)dr["Logradouro"],
                    Number = (int)dr["Numero"],
                    District = (string)dr["Bairro"],
                    ZipCode = (string)dr["CEP"],
                    Complement = (string)dr["Complemento"],
                    city = new City()
                    {
                        Id = (int)dr["Cidade"],
                        Description = (string)dr["Descricao"],
                        RegisterDate = (DateTime)dr["data"]
                    },
                    RegisterDate = (DateTime)dr["dataendereço"]
                };

                ticket.client = new Client()
                {
                    Id = (int)dr["Id"],
                    Name = (string)dr["Name"],
                    Phone = (string)dr["Phone"],
                    address = new Address()
                    {
                        Id = (int)dr["Id"],
                        Street = (string)dr["Logradouro"],
                        Number = (int)dr["Numero"],
                        District = (string)dr["Bairro"],
                        ZipCode = (string)dr["CEP"],
                        Complement = (string)dr["Complemento"],
                        city = new City()
                        {
                            Id = (int)dr["Id"],
                            Description = (string)dr["Descricao"],
                            RegisterDate = (DateTime)dr["data"]
                        },
                        RegisterDate = (DateTime)dr["DTCadastro"]
                    }
                };
                ticket.Date = (DateTime)dr["RegisterDate"];
                ticketlist.Add(ticket);
            }
            return ticketlist;
        }


        public bool Update(int id, double price)
        {
            bool status = false;

            try
            {
                string strUpdate = "update Ticket Set Price = " + "'" + price + "' where Id = " + id;

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
                string strDelete = $"Delete from Ticket where Id = {id}";

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
