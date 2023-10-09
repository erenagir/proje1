using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
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
            builder.ToTable("PERSONS");

            builder.Property(x => x.departmantId)
            .HasColumnName("DEPARTMENT_ID")
            .HasColumnOrder(2);
            
            builder.Property(x=> x.Name)
                .HasColumnName("NAME")
                .HasColumnType("nvarchar(30)")
                .HasColumnOrder(4);
            builder.Property(x => x.Surname)
               .HasColumnName("SURNAME")
               .HasColumnType("nvarchar(30)")
               .HasColumnOrder(5);

            builder.Property(x => x.Email)
            .HasColumnName("EMAİL")
            .HasColumnType("nvarchar(150)")
            .HasColumnOrder(6);
            builder.Property(x => x.UserName)
                .HasColumnName("USERNAME")
                .HasColumnType("nvarchar(20)")
                .HasColumnOrder(7);
            builder.Property(x => x.Password)
                .HasColumnName("PASSWORD")
                .HasColumnOrder(8);

            builder.HasOne(x => x.Department)
               .WithMany(x => x.Persons)
               .HasForeignKey(x => x.departmantId)
               .OnDelete(DeleteBehavior.NoAction)
               .HasConstraintName("PERSONS_Department_DEPARTMENT_ID");


            builder.Property(x => x.Role)
                .HasColumnName("ROLES")
                .HasColumnOrder(9);

        }
    }
}



