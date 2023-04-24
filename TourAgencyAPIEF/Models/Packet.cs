using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismo.Models
{
    public class Packet
    {
        public int Id { get; set; }
        public Hotel hotel { get; set; }
        public Ticket ticket { get; set; }
        public DateTime RegisterDate { get; set; }
        public Client client { get; set; }
        public double Price { get; set; }
    }
}
