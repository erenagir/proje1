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
    public class CompanyMapping : BaseEntityMapping<Company>
    {
        public override void ConfigureDerivedEntity(EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.CompanyName)
                .HasColumnName("COMPANY_NAME")
                .HasColumnType("nvarchar(150)")
                .HasColumnOrder(2);
            builder.ToTable("COMPANY");
        }
    }
}
