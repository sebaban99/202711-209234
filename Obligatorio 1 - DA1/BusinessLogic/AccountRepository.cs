using BusinessLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;

namespace BusinessLogic
{
    public class AccountRepository : ParkingRepository<Account>
    {
        public AccountRepository(ParkingContext context)
        {
            Context = context;
        }

        public override void Update(Account modifiedEntity)
        {
            try
            {
                Account accountToUpdate =
              Context.Accounts.FirstOrDefault(a => a.Id == modifiedEntity.Id);

                if (accountToUpdate == null)
                {
                    throw new DatabaseException("La cuenta que esta intentando " +
                        "actualizar no se encuentra en la base de datos");
                }
                accountToUpdate.Balance = modifiedEntity.Balance;
                Context.SaveChanges();
            }
            catch (DbException)
            {
                throw new DatabaseException("Database Error");
            }
        }

        public override Account Get(string phoneNumber, string countryTag)
        {
            try
            {
                return Context.Accounts.Where(a =>
                    a.Phone.Equals(phoneNumber) &&
                    a.CountryTag.Equals(countryTag)).FirstOrDefault();
            }
            catch (DbException)
            {
                throw new DatabaseException("Database Error");
            }
        }

    }
}