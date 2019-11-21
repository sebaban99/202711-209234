using System;
using System.Collections.Generic;
using BusinessLogic.Domain;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Persistance
{
    public class ParkingContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<CostPerMinute> Costs { get; set; }

        public ParkingContext() : base() { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostPerMinute>().ToTable("CostsPerMinute");
            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<Purchase>().ToTable("Purchases");
        }
    }
}
