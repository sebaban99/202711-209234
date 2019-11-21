using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using BusinessLogic.Persistance;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public abstract class ParkingRepository<T> : IRepository<T> where T : class
    {
        public ParkingContext Context { get; set; }

        public virtual void Add(T entity)
        {
            try
            {
                Context.Set<T>().Add(entity);
                Context.SaveChanges();
            }
            catch (DbException)
            {
                throw new DatabaseException("Database Error");
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return Context.Set<T>().ToList();
            }
            catch (DbException)
            {
                throw new DatabaseException("Database Error");
            }
        }

        public abstract T Get(string key, string countryTag);

        public virtual void Update(T entitiy) { }

        public void Empty()
        {
            try
            {
                foreach (T a in Context.Set<T>().ToList())
                {
                    Context.Set<T>().Remove(a);
                    Context.SaveChanges();
                }
            }
            catch (DbException)
            {
                throw new DatabaseException("Database Error");
            }
        }




    }
}
