using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismo.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public Address Start { get; set; }
        public Address Destination { get; set; }
        public Client client { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set;}
    }
}
