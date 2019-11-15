﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;

namespace BusinessLogic
{
    public class PurchaseRepository
    {
        public ParkingContext Context { get; set; }


        public void Add(Purchase entity)
        {
            try
            {
                Context.Set<Purchase>().Add(entity);
                Context.SaveChanges();
            }
            catch (DbException ex)
            {
                throw new DatabaseException("Database Error", ex);
            }
        }


        public IEnumerable<Purchase> GetAll()
        {
            return Context.Purchases.ToList();
        }

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