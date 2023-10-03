using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Proje1.Persistence.Mapping
{
    public class PersonMapping : BaseEntityMapping<Person>
    {
        public override void ConfigureDerivedEntity(EntityTypeBuilder<Person> builder)
        {
           builder.Property(x=> x.Name)
                .HasColumnName("NAME")
                .HasColumnType("nvarchar(30)")
                .HasColumnOrder(2);
            builder.Property(x => x.Surname)
               .HasColumnName("SURNAME")
               .HasColumnType("nvarchar(30)")
               .HasColumnOrder(3);

            builder.Property(x => x.Email)
            .HasColumnName("EMAİL")
            .HasColumnType("nvarchar(150)")
            .HasColumnOrder(4);

            builder.Property(x => x.Role)
            .HasColumnName("ROLE_ID")
           .HasColumnOrder(5);
            builder.ToTable("PERSONS");
        }
    }
}

