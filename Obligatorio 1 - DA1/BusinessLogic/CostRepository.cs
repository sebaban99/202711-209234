using BusinessLogic.Exceptions;
using System;
using System.Data.Common;
using System.Linq;

namespace BusinessLogic
{
    public class CostRepository : ParkingRepository<CostPerMinute>
    {
        public CostRepository(ParkingContext context)
        {
            Context = context;
        }

        public override void Add(CostPerMinute entity)
        {
            try
            {
                CostPerMinute costToAdd =
               Context.Costs.FirstOrDefault(c => c.CountryTag == entity.CountryTag);

                if (costToAdd == null)
                {
                    Context.Set<CostPerMinute>().Add(entity);
                    Context.SaveChanges();
                }
                else
                {
                    throw new DatabaseException("Ya existe un costo asociado al pais," +
                        " si quiere modificarlo actualizelo");
                }
            }
            catch (DbException)
            {
                throw new DatabaseException("Database Error");
            }
        }

        public override CostPerMinute Get(string key, string countryTag)
        {
            try
            {
                return Context.Costs.Where(c =>
                    c.CountryTag.Equals(countryTag)).FirstOrDefault();
            }
            catch (DbException)
            {
                throw new DatabaseException("El costo" +
                    " no se encuentra en la base de datos");
            }
        }

        public override void Update(CostPerMinute modifiedCost)
        {
            try
            {
                CostPerMinute costToUpdate = Context.Costs.FirstOrDefault(
                    c => c.CountryTag == modifiedCost.CountryTag);

                if (costToUpdate == null)
                {
                    throw new DatabaseException("El costo que esta intentando " +
                        "actualizar no se encuentra en la base de datos");
                }
                costToUpdate.Value = modifiedCost.Value;
                Context.SaveChanges();
            }
            catch (DbException)
            {
                throw new DatabaseException("DatabaseException");
            }
        }
    }
}