using Data.Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Repository<T> where T : class
    {
        private NorthwindEntities context;

        public Repository()
        {
            context = new NorthwindEntities();
        }

        public T Persist(T entity)
        {
            return context.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public T Update(T entity)
        {
            context.Entry<T>(entity);
            return entity;
        }

        public IQueryable<T> Set()
        {
            return context.Set<T>();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

    }
}
