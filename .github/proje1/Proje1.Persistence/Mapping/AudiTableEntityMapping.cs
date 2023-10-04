using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje1.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.Persistence.Mapping
{
    public abstract class AudiTableEntityMapping<T> : IEntityTypeConfiguration<T> where T : AuditableEntity
    {
        public abstract void ConfigureDerivedEntity(EntityTypeBuilder<T> builder);
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
               .HasColumnName("ID")
               .HasColumnOrder(1);

            ConfigureDerivedEntity(builder);
           
            builder.Property(x => x.CreateBy)
                .HasColumnName("CREATE_BY")
                .HasColumnType("nvarchar(20)")
                .HasColumnOrder(36);
           
            builder.Property(x => x.CreatedDate)
               .HasColumnName("CREATE_DATE")
               .HasColumnOrder(37);

            builder.Property(x => x.ModifiedBy)
               .HasColumnName("MODIFIED_BY")
               .HasColumnType("nvarchar(20)")
               .IsRequired(false)
               .HasColumnOrder(38);
           
            builder.Property(x => x.ModifiedDate)
               .HasColumnName("MODIFIED_DATE")
               .IsRequired(false)
               .HasColumnOrder(39);



            builder.Property(x => x.IsDeleted)
                .HasColumnName("IS_DELETED")
                .HasColumnOrder(40)
                .HasDefaultValueSql("0");
        }
    }
}
