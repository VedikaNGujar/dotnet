﻿using BubberDinner.Domain.HostAggregator.ValueObjects;
using BubberDinner.Domain.MenuAggregator;
using BubberDinner.Domain.MenuAggregator.Entities;
using BubberDinner.Domain.MenuAggregator.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BubberDinner.Infrastructure.Persistence.Configurations
{
    public class MenuConfigurations : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            ConfigureMenusTable(builder);
            ConfigureMenusSectionsTable(builder);
            ConfigureMenuDinnerIdsTable(builder);
            ConfigureMenuReviewIdsTable(builder);
        }

        private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.MenuReviewIds, di =>
            {
                di.ToTable("MenuReviewIds");

                di.WithOwner().HasForeignKey("MenuId");

                di.HasKey("Id");

                di.Property(d => d.Value)
                .HasColumnName("ReviewId")
                .ValueGeneratedNever();

            });

            builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.DinnerIds, di =>
            {
                di.ToTable("MenuDinnerIds");

                di.WithOwner().HasForeignKey("MenuId");

                di.HasKey("Id");

                di.Property(d => d.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever();

            });

            builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenusSectionsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.Sections, sb =>
            {
                sb.ToTable("MenuSections");

                sb.WithOwner().HasForeignKey("MenuId");

                sb.HasKey("Id", "MenuId");

                sb.Property(s => s.Id)
                .HasColumnName("MenuSectionId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuSectionId.Create(value));

                sb.Property(s => s.Name)
               .HasMaxLength(100);

                sb.Property(s => s.Description)
                   .HasMaxLength(100);

                sb.OwnsMany(s => s.Items, ib =>
                {

                    ib.ToTable("MenuItems");

                    ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                    ib.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");


                    ib.Property(s => s.Id)
                    .HasColumnName("MenuItemId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => MenuItemId.Create(value));

                    ib.Property(s => s.Name)
                    .HasMaxLength(100);

                    ib.Property(s => s.Description)
                    .HasMaxLength(100);

                });

                sb.Navigation(nameof(MenuSection.Items))
                .Metadata.SetField("_items");
                sb.Navigation(nameof(MenuSection.Items))
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            });

            builder.Metadata.FindNavigation(nameof(Menu.Sections))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .ValueGeneratedNever()
                .HasConversion(
                id => id.Value,
                value => MenuId.Create(value));

            builder.Property(m => m.Name)
                .HasMaxLength(100);

            builder.Property(m => m.Description)
               .HasMaxLength(100);

            builder.OwnsOne(m => m.AverageRating);

            builder.Property(m => m.HostId)
               .ValueGeneratedNever()
               .HasConversion(
               id => id.Value,
               value => HostId.Create(value));

        }
    }
}
