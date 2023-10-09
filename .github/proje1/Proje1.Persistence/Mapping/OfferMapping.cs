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
    public class OfferMapping : AudiTableEntityMapping<Offer>
    {
        public override void ConfigureDerivedEntity(EntityTypeBuilder<Offer> builder)
        {
            builder.Property(x => x.RequestformId)
               .HasColumnName("REQUESTFORM_ID")
               .HasColumnOrder(3);

            builder.Property(x => x.CompanyName)
                .HasColumnName("COMPANY_NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(4);
            builder.Property(x => x.Address)
               .HasColumnName("ADDRESS")
               .HasColumnType("nvarchar(30)")
               .HasColumnOrder(5);

            builder.Property(x => x.CompanyEmail)
                .HasColumnName("COMPANY_EMAİL")
                .HasColumnType("nvarchar(150)")
                .HasColumnOrder(6);

            builder.Property(x => x.CompanyPhone)
                .HasColumnName("COMPANY_PHONE")
                .HasColumnType("nvarchar(10)")
                .HasColumnOrder(7);

            builder.Property(x => x.TotalPrice)
                .HasColumnName("TOTAL_PRICE")
                .HasColumnOrder(8);

            builder.HasOne(x => x.RequestForm)
                .WithMany(x => x.Offers)
                .HasForeignKey(x => x.RequestformId)
                .HasConstraintName("REQUESTFORM_OFFERS_REQUESTFORMID");
            builder.ToTable("OFFERS");
        }

    }
}


