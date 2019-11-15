using BusinessLogic.Exceptions;
using System;
using System.Data.Common;
using System.Linq;

namespace BusinessLogic
{
    public class CostRepository
    {
        public ParkingContext Context { get; set; }

        public void Add(CostPerMinute entity)
        {
            try
            {
                Context.Set<CostPerMinute>().Add(entity);
                Context.SaveChanges();
            }
            catch (DbException ex)
            {
                throw new DatabaseException("Database Error", ex);
            }
        }

        public CostPerMinute Get(string countryTag)
        {
            try
            {
                return Context.Costs.Where(c =>
                    c.CountryTag.Equals(countryTag)).FirstOrDefault();
            }
            catch (DatabaseException)
            {
                return null;
            }
        }

        public void Empty()
        {
            try
            {
                foreach (CostPerMinute c in Context.Costs.ToList())
                {
                    Context.Costs.Remove(c);
                    Context.SaveChanges();
                }
            }
            catch (DbException ex)
            {
                throw new DatabaseException("Database Error", ex);
            }
        }

        public void Update(CostPerMinute modifiedCost)
        {
            CostPerMinute costToUpdate =
                Context.Costs.First(c => c.Id == modifiedCost.Id);

            if (costToUpdate == null)
            {
                throw new DatabaseException("El costo que esta intentando " +
                    "actualizar no se encuentra en la base de datos");
            }
            Context.Costs.Attach(costToUpdate);
            costToUpdate.Value = modifiedCost.Value;
            Context.SaveChanges();
        }
    }
}