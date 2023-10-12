using Microsoft.EntityFrameworkCore;
using Proje1.Domain.Common;
using Proje1.Domain.Entities;
using Proje1.Persistence.Mapping;

namespace Proje1.Persistence.Context
{
    public class ProjeContext : DbContext
    {
        public ProjeContext(DbContextOptions<ProjeContext> options) : base(options)
        {

        }
        public DbSet<Authority> Authorities { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Invoice> Invoicess { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<RequestForm> RequestForms { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorityMapping());
            modelBuilder.ApplyConfiguration(new CompanyMapping());
            modelBuilder.ApplyConfiguration(new DepartmentMapping());
            modelBuilder.ApplyConfiguration(new InvoiceMapping());
            modelBuilder.ApplyConfiguration(new OfferMapping());
            modelBuilder.ApplyConfiguration(new PersonMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new ReportMapping());
            modelBuilder.ApplyConfiguration(new RequestFormMapping());

            modelBuilder.Entity<Company>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Department>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Invoice>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Offer>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Person >().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Product>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<Report>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            modelBuilder.Entity<RequestForm>().HasQueryFilter(x => x.IsDeleted == null || (x.IsDeleted.HasValue && !x.IsDeleted.Value));
            

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
                            auditableEntity.ModifiedBy = "admin";
                            break;
                        //insert
                        case EntityState.Added:
                            auditableEntity.CreatedDate = DateTime.Now;
                            auditableEntity.CreateBy = "admin";
                            break;
                        //delete
                        case EntityState.Deleted:
                            auditableEntity.ModifiedDate = DateTime.Now;
                            auditableEntity.ModifiedBy = "admin";
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
