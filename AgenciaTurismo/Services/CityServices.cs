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

        private ICityRepository touragecyRepository;

        public CityServices()
        {
            touragecyRepository = new CityRepository();
        }

        public bool InsertDapper(City city)
        {
            return touragecyRepository.InsertDapper(city);
        }

        public List<City> GetAllDapper()
        {
            return touragecyRepository.GetAllDapper();
        }

        public bool UpdateDapper(City city)
        {
            return touragecyRepository.UpdateDapper(city);
        }

        public bool DeleteDapper(City city)
        {
            return touragecyRepository.DeleteDapper(city);
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
