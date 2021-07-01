using Microsoft.EntityFrameworkCore;// for DbContext
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsSalesApp.Models;

namespace WinFormsSalesApp.Data
{
    class SalesContext: DbContext
    {
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SalesPerson> People { get; set; }
        public DbSet<SalesRegion> Regions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }


        public override int SaveChanges()
        {
            //ChangeTracker.DetectChanges();
            //var stateManager = (IObjectContextAdapter)
            return base.SaveChanges();
        }

    }
}
