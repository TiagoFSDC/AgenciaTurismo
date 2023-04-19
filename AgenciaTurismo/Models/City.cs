using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismo.Models
{
    public class City
    {
        public readonly static string INSERT = "insert into Cidade(Descricao) " +
                    "  values (@Descricao):";
        public readonly static string GETALL = "select Descricao from Cidade";

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime RegisterDate { get; set; }

        //public override string ToString()
        //{
        //    return $"Id = {Id}\nDescrição: {Description}\nData de registro: {RegisterDate}";
        //}

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
