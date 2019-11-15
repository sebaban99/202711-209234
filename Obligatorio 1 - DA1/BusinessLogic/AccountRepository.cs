using BusinessLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
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
            catch (DbException)
            {
                throw new DatabaseException("Database Error");
            }
        }

        public void Update(Account modifiedEntity)
        {
            Account accountToUpdate = 
                Context.Accounts.First(a => a.Id == modifiedEntity.Id);

            if (accountToUpdate == null)
            {
                throw new DatabaseException("La cuenta que esta intentando " +
                    "actualizar no se encuentra en la base de datos");
            }
            Context.Accounts.Attach(accountToUpdate);
            accountToUpdate.Balance = modifiedEntity.Balance;
            Context.SaveChanges();
        }

        public Account Get(string phoneNumber, string countryTag)
        {
            try
            {
                return Context.Accounts.Where(a =>
                    a.Phone.Equals(phoneNumber) &&
                    a.CountryTag.Equals(countryTag)).FirstOrDefault();
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
            catch (DbException)
            {
                throw new DatabaseException("Database Error");
            }
        }
    }
}