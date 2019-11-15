using BusinessLogic.Exceptions;
using System;
using System.Data.Common;
using System.Linq;

namespace BusinessLogic
{
    public class AccountRepository
    {
        public ParkingContext Context { get; set; }

        public void Empty()
        {
            try
            {
                foreach (Purchase p in Context.Purchases.ToList())
                {
                    Context.Purchases.Remove(p);
                    Context.SaveChanges();
                }
            }
            catch (DbException ex)
            {
                throw new DatabaseException("Database Error", ex);
            }
        }
    }
}