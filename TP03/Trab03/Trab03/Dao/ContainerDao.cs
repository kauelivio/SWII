using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trab03.Data;
using Trab03.Models;

namespace Trab03.Dao
{
    public class ContainerDao
    {

        public void Adicionar(Container container)
        {
            using (var context = new BancoContext())
            {
                context.Containers.Add(container);
                context.SaveChanges();
            }
        }

        public IList<Container> Lista()
        {
            using (var context = new BancoContext())
            {
                return context.Containers.Include("Booking").ToList();
            }
        }

        public Container BuscarPorId(int id)
        {
            using (var context = new BancoContext())
            {
                return context.Containers.Include("Booking").Where(c => c.Id == id).FirstOrDefault();
            }
        }

        public void Atualizar(Container container)
        {
            using (var context = new BancoContext())
            {
                context.Entry(container).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}