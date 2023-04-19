using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Services
{
    public class PacketServices
    {
        readonly string strconn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\dev-aula\AgenciaTurismo\AgenciaTurismo\docs\Scripts\AgenciaTurismo.mdf";
        readonly SqlConnection Conn;

        public PacketServices()
        {
            Conn = new SqlConnection(strconn);
            Conn.Open();
        }

        public bool Insert(Packet packet)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Packet (HotelId,TiketId,Price,ClientId) " +
                    "values (@HotelId, @TicketId,@Price,@ClientId)";

                SqlCommand commandInsert = new SqlCommand(strInsert, Conn);

                commandInsert.Parameters.Add(new SqlParameter("@HotelId", InsertHotel(packet)));
                commandInsert.Parameters.Add(new SqlParameter("@TiketId", InsertTicket(packet)));
                commandInsert.Parameters.Add(new SqlParameter("@ClientId", InsertClient(packet)));
                commandInsert.Parameters.Add(new SqlParameter("@Price", packet.Price));

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

        private int InsertHotel(Packet packet)
        {
            string strInsert = "insert into Hotel (Name, IdAddress, Price) " +
                "values (@Name, @IdAddress, @Price)";

            SqlCommand commandInsert = new SqlCommand(strInsert, Conn);

            commandInsert.Parameters.Add(new SqlParameter("@Name", packet.hotel.Name));
            commandInsert.Parameters.Add(new SqlParameter("@IdAddress", InsertAddress(packet)));
            commandInsert.Parameters.Add(new SqlParameter("@Price", packet.hotel.Price));

            return (int)commandInsert.ExecuteScalar();
        }

        private int InsertAddress(Packet packet)
        {
            string strInsert = "insert into Endereco (Logradouro, Numero, Bairro, CEP, Complemento, IdCidade) " +
                "values (@Logradouro, @Numero, @Bairro, @CEP, @Complemento, @IdCidade); select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, Conn);

            commandInsert.Parameters.Add(new SqlParameter("@Logradouro", packet.hotel.address.Street));
            commandInsert.Parameters.Add(new SqlParameter("@Numero", packet.hotel.address.Number));
            commandInsert.Parameters.Add(new SqlParameter("@Bairro", packet.hotel.address.District));
            commandInsert.Parameters.Add(new SqlParameter("@CEP", packet.hotel.address.ZipCode));
            commandInsert.Parameters.Add(new SqlParameter("@Complemento", packet.hotel.address.Complement));
            commandInsert.Parameters.Add(new SqlParameter("@IdCidade", InsertCity(packet.hotel.address)));

            return (int)commandInsert.ExecuteScalar();
        }

        private int InsertTicket(Packet packet)
        {
            string strInsert = "insert into Ticket (StartId, DestinationId,ClientId, Price) " +
                                "values (@StartId, @DestinationId, @ClientId, @Price)";

            SqlCommand commandInsert = new SqlCommand(strInsert, Conn);

            commandInsert.Parameters.Add(new SqlParameter("@StartId", InsertAddressS(packet.ticket)));
            commandInsert.Parameters.Add(new SqlParameter("@DestinationId", InsertAddressD(packet.ticket)));
            commandInsert.Parameters.Add(new SqlParameter("@ClientId", InsertClient(packet)));
            commandInsert.Parameters.Add(new SqlParameter("@Price", packet.ticket.Price));

            return (int)commandInsert.ExecuteScalar();
        }

        private int InsertClient(Packet packet)
        {
            string strInsert = "insert into Client (Name, Phone, IdEndereco) "
                + "values (@Name, @Phone, @IdEndereco); select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, Conn);

            commandInsert.Parameters.Add(new SqlParameter("@Name", packet.client.Name));
            commandInsert.Parameters.Add(new SqlParameter("@Phone", packet.client.Phone));
            commandInsert.Parameters.Add(new SqlParameter("@IdEndereco", InsertAddressS(packet.ticket)));

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

        public bool Update(int id, double price)
        {
            bool status = false;

            try
            {
                string strUpdate = "update Packet Set Price = " + "'" + price + "' where Id = " + id;

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
                string strDelete = $"Delete from Packet where Id = {id}";

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
