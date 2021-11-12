using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trab03.Models
{
    public class Container
    {
        public int Id { get; set; }

        public int IdBooking { get; set; }

        public Booking Bl { get; set; }

        public int Numero { get; set; }

        public string Tipo { get; set; }

        public string Tamanho { get; set; }

    }
}