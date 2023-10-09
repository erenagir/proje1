using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using Proje1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Persistence.Mapping
{
    public class AuthorityMapping : BaseEntityMapping<Authority>
    {
        public override void ConfigureDerivedEntity(EntityTypeBuilder<Authority> builder)
        {
            builder.Property(x => x.PersonId)
                .HasColumnName("PERSON_ID")
                .HasColumnOrder(2);
            
            builder.Property(x => x.Admin)
                .HasColumnName("IS_ADMIN")
                .HasColumnOrder(3);
            builder.Property(x => x.Request)
                .HasColumnName("IS_REQUEST")
                .HasColumnOrder(5);
            builder.Property(x => x.Approve)
                .HasColumnName("IS_APPROVE")
                .HasColumnOrder(6);
            builder.Property(x => x.Receive)
                .HasColumnName("IS_RECEIVE")
                .HasColumnOrder(7);
            builder.Property(x => x.Accounting)
                .HasColumnName("IS_ACCOUNTING")
                .HasColumnOrder(8);
            builder.Property(x => x.management)
                .HasColumnName("IS_MANAGEMENT")
                .HasColumnOrder(9);

         //  builder.HasOne(x => x.Person)
                //.WithOne(x => x.Authority)
                //.HasForeignKey<Authority>(x => x.PersonId);

           
            builder.ToTable("AUTHORITY");
        }
    }
}


