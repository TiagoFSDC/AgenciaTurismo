﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;
using Dapper;
using static System.Formats.Asn1.AsnWriter;

namespace AgenciaTurismo.Repositories
{
    public class TourAgencyRepository : ITourAgencyRepository
    {
        private readonly string _strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\dev-aula\AgenciaTurismo\AgenciaTurismo\docs\Scripts\AgenciaTurismo.mdf";
        //readonly SqlConnection conn;

        //public TourAgencyRepository()
        //{
        //    conn = new SqlConnection(strConn);
        //    conn.Open();
        //}

        public List<City> GetAllDapper()
        {
            List<City> citylist = new();

            using (var db = new SqlConnection(_strConn))
            {
                var cities = db.Query<City>(City.GETALL);
                citylist = (List<City>)cities;
            }
            return citylist;
        }

        public bool InsertDapper(City city)
        {
            var status = false;
            using (var db = new SqlConnection(_strConn))
            {
                db.Open();
                db.Execute(City.INSERT, city);
                status = true;
            }
            return status;
        }
    }
}
