using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trab03.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int Numero { get; set; }

        public string Consignee { get; set; }

        public string Navio { get; set; }

    }
}