using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismo.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address address { get; set; }
        public DateTime RegisterDate { get; set; }
        public double Price { get; set; }
    }
}
