using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;
using AgenciaTurismo.Services;

namespace AgenciaTurismo.Controllers
{
    public class TicketController
    {
        public bool Insert(Ticket ticket)
        {
            return new TicketServices().Insert(ticket);
        }

        //public List<Ticket> FindAll()
        //{
        //    return new TicketServices().FindAll();
        //}

        public bool Update(int id, double price)
        {
            return new TicketServices().Update(id, price);
        }

        public bool Delete(int id)
        {
            return new TicketServices().Delete(id);
        }
    }
}
