using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;
using AgenciaTurismo.Repositories;
using static System.Formats.Asn1.AsnWriter;

namespace AgenciaTurismo.Services
{
    internal class CityServices
    {
        readonly string strconn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\dev-aula\AgenciaTurismo\AgenciaTurismo\docs\Scripts\AgenciaTurismo.mdf";
        readonly SqlConnection Conn;

        private ITourAgencyRepository touragecyRepository;

        public CityServices()
        {
            touragecyRepository = new TourAgencyRepository();
        }

        public bool InsertDapper(City city)
        {
            return touragecyRepository.InsertDapper(city);
        }

        public List<City> GetAllDapper()
        {
            return touragecyRepository.GetAllDapper();
        }
        //public CityServices()
        //{
        //    Conn = new SqlConnection(strconn);
        //    Conn.Open();
        //}
        public bool Insert(City city)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Cidade (Descricao) " +
                    "values (@Descricao)";

                SqlCommand commandInsert = new SqlCommand(strInsert, Conn);

                commandInsert.Parameters.Add(new SqlParameter("@Description", city.Description));

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

        public List<City> FindAll()
        {
            List<City> cities = new();
            StringBuilder sb = new StringBuilder();

            sb.Append("select c.Id, c.Descricao,c.Dtcadastro from Cidade c");

            SqlCommand commandSelect = new(sb.ToString(), Conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                City city = new();

                city.Id = (int)dr["Id"];
                city.Description = (string)dr["Descricao"];
                city.RegisterDate = (DateOnly)dr["Dtcadastro"];

                cities.Add(city);
            }
            return cities;
        }

        public bool Update(City city, int id, string desc)
        {
            bool status = false;

            try 
            {
                string strUpdate = "update Cidade Set Descricao = " + "'" + desc + "' where Id = "+ id;

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
                string strDelete = $"Delete from Cidade where Id = {id}";

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
