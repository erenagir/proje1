using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Persistence.Mapping
{
    public class AccountMapping : BaseEntityMapping<Account>
    {
        public override void ConfigureDerivedEntity(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.PersonId)
                 .HasColumnName("PERSON_ID")
                 .HasColumnOrder(2);
            builder.Property(x=>x.UserName)
                .HasColumnName("USERNAME")
                .HasColumnType("nvarchar(20)")
                .HasColumnOrder(3);
            builder.Property(x=>x.Password)
                .HasColumnName("PASSWORD")
                .HasColumnOrder (4);

            builder.HasOne(x => x.Person)
               .WithOne(x => x.Account)
               .HasForeignKey<Account>(x => x.PersonId);
            builder.ToTable("ACCOUNTS");
        }
    }
}

