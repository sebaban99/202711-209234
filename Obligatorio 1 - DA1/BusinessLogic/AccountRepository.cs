using BusinessLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace BusinessLogic
{
    public class AccountRepository
    {
        public ParkingContext Context { get; set; }

        public IEnumerable<Purchase> GetAll()
        {
            return Context.Accounts.ToList();
        }

        public void Empty()
        {
            try
            {
                foreach (Account a in Context.Accounts.ToList())
                {
                    Context.Accounts.Remove(a);
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