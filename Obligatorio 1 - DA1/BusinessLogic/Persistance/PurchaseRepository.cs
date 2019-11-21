using System;
using System.Collections.Generic;
using System.Data.Common;
using BusinessLogic.Domain;
using System.Linq;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Persistance
{
    public class PurchaseRepository : ParkingRepository<Purchase>
    {
        public PurchaseRepository(ParkingContext context)
        {
            Context = context;
        }

        public override Purchase Get(string licensePlate, string countryTag)
        {
            try
            {
                return Context.Purchases.Where(p =>
                p.LicensePlate.Equals(licensePlate) &&
                p.CountryTag.Equals(countryTag)).FirstOrDefault();
            }
            catch (DbException)
            {
                throw new DatabaseException("Database Error");
            }
        }
    }
}