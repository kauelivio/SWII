using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Trab03.Models;

namespace Trab03.Data
{
    public class BancoContext : DbContext
    {

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Container> Containers { get; set; }

    }
}