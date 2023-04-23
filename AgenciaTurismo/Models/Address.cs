using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismo.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string District { get; set; }
        public string ZipCode { get; set; }
        public string Complement { get; set; }
        public City city { get; set; }
        public DateTime RegisterDate { get; set; }

        public override string ToString()
        {
            return $"\n\nId: {Id}\nLogradouro: {Street}\nNumero: {Number}\nBairro: {District}\nCEP: {ZipCode}" +
                $"\nComplemento: {Complement}\nData: {RegisterDate}\nCidade: {city}";
        }
    }
}
