using Microsoft.EntityFrameworkCore;
using Proje1.Domain.Common;
using Proje1.Domain.Entities;
using Proje1.Persistence.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Persistence.Context
{
    public class ProjeContext:DbContext
    {
        public ProjeContext(DbContextOptions<ProjeContext> options):base(options)
        {
            
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RequestForm> RequestForms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMapping());
            modelBuilder.ApplyConfiguration(new OfferMapping());
            modelBuilder.ApplyConfiguration(new PersonMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new RequestFormMapping());
           

        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            //Herhangi bir kayıt işleminde yapılan işlem ekleme ise CreateDate ve CreatedBy bilgileri otomatik olarak set edilir.
            //Herhangi bir kayıt işleminde yapılan işlem güncelleme ise ModifiedDate ve ModifiedBy bilgileri otomatik olarak set edilir.

            var entries = ChangeTracker.Entries<BaseEntity>().ToList();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Deleted)
                {
                    entry.Entity.IsDeleted = true;
                    entry.State = EntityState.Modified;
                }

                if (entry.Entity is AuditableEntity auditableEntity)
                {
                    switch (entry.State)
                    {
                        //update
                        case EntityState.Modified:
                            auditableEntity.ModifiedDate = DateTime.Now;
                            auditableEntity.ModifiedBy =  "admin";
                            break;
                        //insert
                        case EntityState.Added:
                            auditableEntity.CreatedDate = DateTime.Now;
                            auditableEntity.CreateBy = "admin";
                            break;
                        //delete
                        case EntityState.Deleted:
                            auditableEntity.ModifiedDate = DateTime.Now;
                            auditableEntity.ModifiedBy =  "admin";
                            break;
                        default:
                            break;
                    }
                }

            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
