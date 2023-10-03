﻿using Microsoft.EntityFrameworkCore;
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
            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(2);
            builder.Property(x => x.Detail)
               .HasColumnName("DETAİL")
               .HasColumnType("nvarchar(max)")
               .HasColumnOrder(3);

            builder.Property(x => x.Products)
            .HasColumnName("COMPANY_EMAİL")
            .HasColumnType("nvarchar(max)")
            .HasColumnOrder(4);
            builder.ToTable("REQUESTFORM");
        }
    }
}
