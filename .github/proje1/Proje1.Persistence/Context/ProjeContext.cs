using Microsoft.EntityFrameworkCore;
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

    }
}
