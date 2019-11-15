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

        public void Add(Account entity)
        {
            try
            {
                Context.Set<Account>().Add(entity);
                Context.SaveChanges();
            }
            catch (DbException ex)
            {
                throw new DatabaseException("Database Error", ex);
            }
        }

        public Account Get(string phoneNumber, string countryTag)
        {
            try
            {
                return Context.Accounts.FirstOrDefault(a =>
                a.Phone.Equals(phoneNumber) &&
                a.CountryTag.Equals(countryTag));
            }
            catch (DatabaseException)
            {
                return null;
            }
        }

        public IEnumerable<Account> GetAll()
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