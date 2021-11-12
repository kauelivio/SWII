using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trab03.Data;
using Trab03.Models;

namespace Trab03.Dao
{
    public class BookingDao
    {
        public void Adicionar(Booking booking)
        {
            using (var context = new BancoContext())
            {
                context.Bookings.Add(booking);
                context.SaveChanges();
            }
        }

        public IList<Booking> Lista()
        {
            using (var context = new BancoContext())
            {
                return context.Bookings.ToList();
            }
        }

        public Booking BuscarPorId(int id)
        {
            using (var context = new BancoContext())
            {
                return context.Bookings.Where(c => c.Id == id).FirstOrDefault();
            }
        }

        public void Atualizar(Booking booking)
        {
            using (var context = new BancoContext())
            {
                context.Entry(booking).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}