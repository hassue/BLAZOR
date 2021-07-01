using Microsoft.EntityFrameworkCore; // for  :DbContext
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SamuraiApp.Domain;
using System;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {

        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-A5O00MD;Initial Catalog=SamuraiAppData;
            Integrated Security=False;Persist Security Info=True;User ID=sa;Password=123;Pooling=False;
            MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False");
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is IActive iactive)
                {
                    switch (entry.State)
                    {
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            iactive.Active = false;
                            break;

                        case EntityState.Added:
                            iactive.Active = true;
                            break;
                    }

                }
                if (entry.Entity is BaseModel baseModel)
                {
                    var now = DateTime.UtcNow;
                    var user = GetCurrentUser();
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            baseModel.LastUpdatedDate = now;
                            baseModel.LastUpdatedBy = user;
                            break;

                        case EntityState.Added:
                            baseModel.CreatedDate = now;
                            baseModel.CreatedBy = user;
                            baseModel.LastUpdatedDate = now;
                            baseModel.LastUpdatedBy = user;
                            break;
                    }
                }


            }
        }
        private string GetCurrentUser()
        {
            return "UserName"; // TODO implement your own logic

            // If you are using ASP.NET Core, you should look at this answer on StackOverflow
            // https://stackoverflow.com/a/48554738/2996339
        }
    }
}
