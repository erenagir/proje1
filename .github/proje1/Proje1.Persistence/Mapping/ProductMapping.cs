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
    public class ProductMapping : AudiTableEntityMapping<Product>
    {
        public override void ConfigureDerivedEntity(EntityTypeBuilder<Product> builder)
        {

            builder.Property(x => x.DepartmentId)
                .HasColumnName("DEPARTMENT_ID");
            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(2);
            builder.Property(x => x.ProductDetail)
               .HasColumnName("PRODUCTDETAİL")
               .HasColumnType("nvarchar(MAX)")
               .HasColumnOrder(3);

            builder.Property(x => x.Stock)
            .HasColumnName("STOCK")
            .HasColumnOrder(4);

            builder.HasOne(x => x.Department)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.DepartmentId)
                .HasConstraintName("DEPARTMENT_PRODUCTS_DEPARTMENTID");
            builder.ToTable("PRODUCTS");
        }
    }
}
