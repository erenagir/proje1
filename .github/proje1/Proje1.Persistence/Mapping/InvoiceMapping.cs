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
    public class InvoiceMapping : AudiTableEntityMapping<Invoice>
    {
        public override void ConfigureDerivedEntity(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(x => x.InvoiceDate)
                 .HasColumnName("INVOICE_DATE")
                 .HasColumnOrder(2);
            builder.Property(x => x.CompanyName)
                .HasColumnName("COMPANY_NAME")
                .HasColumnType("nvarchar(40)")
                .HasColumnOrder(3);
            builder.Property(x => x.ProductDetail)
               .HasColumnName("PRODUCT_DETAİL")
               .HasColumnType("nvarchar(max)")
               .HasColumnOrder(4);


        }
    }
}
