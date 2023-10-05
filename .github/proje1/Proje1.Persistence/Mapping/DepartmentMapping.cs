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
    public class DepartmentMapping : BaseEntityMapping<Department>
    {
        public override void ConfigureDerivedEntity(EntityTypeBuilder<Department> builder)
        {
            builder.Property(x => x.CompanyId)
                .HasColumnName("COMPANY_ID")
                .HasColumnOrder(2);
            builder.Property(x => x.DepartmantName)
                .HasColumnName("DEPARTMANT_NAME")
                .HasColumnType("nvarchar(150)")
                .HasColumnOrder(3);

           
            builder.ToTable("DEPARTMENT");
        }
    }
}
