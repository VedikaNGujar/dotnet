﻿using BubberDinner.Domain.BillAggregator;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BubberDinner.Domain.BillAggregator.ValueObjects;
using BubberDinner.Domain.DinnerAggregator.ValueObjects;
using BubberDinner.Domain.GuestAggregator.ValueObjects;
using BubberDinner.Domain.HostAggregator.ValueObjects;

namespace BubberDinner.Infrastructure.Persistence.Configurations
{
    public class BillConfigurations : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            ConfigureBillsTable(builder);
        }

        private static void ConfigureBillsTable(EntityTypeBuilder<Bill> builder)
        {
            builder
                .ToTable("Bills");

            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => BillId.Create(value));

            builder
                .OwnsOne(b => b.Price)
                .Property(x => x.Amount)
                .HasColumnType("decimal(18,2)");

            //builder.Property("Price_Amount")
            //    .HasColumnType("decimal(18,2)");

            builder
                .Property(b => b.DinnerId)
                .HasConversion(
                    id => id.Value,
                    value => DinnerId.Create(value));

            builder
                .Property(b => b.GuestId)
                .HasConversion(
                    id => id.Value,
                    value => GuestId.Create(value));

            builder
                .Property(b => b.HostId)
                .HasConversion(
                    id => id.Value,
                    value => HostId.Create(value));
        }
    }
}
