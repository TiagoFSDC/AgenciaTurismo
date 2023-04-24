using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AgenciaTurismo.Models;

namespace TourAgencyAPIEF.Data
{
    public class TourAgencyAPIEFContext : DbContext
    {
        public TourAgencyAPIEFContext (DbContextOptions<TourAgencyAPIEFContext> options)
            : base(options)
        {
        }

        public DbSet<AgenciaTurismo.Models.City> City { get; set; } = default!;

        public DbSet<AgenciaTurismo.Models.Address>? Address { get; set; }

        public DbSet<AgenciaTurismo.Models.Client>? Client { get; set; }

        public DbSet<AgenciaTurismo.Models.Hotel>? Hotel { get; set; }

        public DbSet<AgenciaTurismo.Models.Ticket>? Ticket { get; set; }

        public DbSet<AgenciaTurismo.Models.Packet>? Packet { get; set; }
    }
}
