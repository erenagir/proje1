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
    public class ReportMapping : BaseEntityMapping<Report>
    {
        public override void ConfigureDerivedEntity(EntityTypeBuilder<Report> builder)
        {
            builder.Property(x => x.PersonID)
                .HasColumnName("PERSON_ID")
                .HasColumnOrder(2);
            builder.Property(x => x.DepartmentId)
                .HasColumnName("DEPARTMENT_ID")
                .HasColumnOrder(3);
            builder.Property(x => x.detail)
                .HasColumnName("DETAİL")
                .HasColumnType("nvarchar(max)")
                .HasColumnOrder(4);
            builder.Property(x => x.Date)
               .HasColumnName("DATE")
               .HasColumnOrder(5);

            builder.HasOne(x => x.Person)
              .WithMany(x => x.Reports)
              .HasForeignKey(x => x.PersonID)
               .HasConstraintName("PERSON_REPORTS_PERSONID");
           
            builder.HasOne(x => x.Department)
              .WithMany(x => x.Reports)
              .HasForeignKey(x => x.DepartmentId)
              .HasConstraintName("DEPARTMENT_REPORTS_PERSONID");

            builder.ToTable("REPORTS");
        }
    }
}


