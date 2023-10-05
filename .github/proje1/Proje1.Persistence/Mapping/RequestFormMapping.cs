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
    public class RequestFormMapping : AudiTableEntityMapping<RequestForm>
    {
        public override void ConfigureDerivedEntity(EntityTypeBuilder<RequestForm> builder)
        {
            builder.Property(x => x.PersonId)
                .HasColumnName("PERSON_ID")
                 .HasColumnOrder(2);

            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(3);
            builder.Property(x => x.Detail)
               .HasColumnName("DETAİL")
               .HasColumnType("nvarchar(max)")
               .HasColumnOrder(4);

            builder.Property(x => x.Products)
                .HasColumnName("COMPANY_EMAİL")
                .HasColumnType("nvarchar(max)")
                .HasColumnOrder(5);

            builder.Property(x => x.Status)
                .HasColumnName("STATUS")
                .HasColumnOrder(6);

            builder.HasOne(x => x.Person)
                .WithMany(x => x.RequestForms)
                .HasForeignKey(x => x.PersonId);
            builder.HasOne(x => x.Invoice);
                

            builder.ToTable("REQUESTFORM");
        }
    }
}
