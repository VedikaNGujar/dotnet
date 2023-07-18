using BubberDinner.Domain.BillAggregator.ValueObjects;
using BubberDinner.Domain.DinnerAggregator;
using BubberDinner.Domain.DinnerAggregator.ValueObjects;
using BubberDinner.Domain.GuestAggregator.ValueObjects;
using BubberDinner.Domain.HostAggregator.ValueObjects;
using BubberDinner.Domain.MenuAggregator.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BubberDinner.Infrastructure.Persistence.Configurations
{
    public class DinnerConfigurations : IEntityTypeConfiguration<Dinner>
    {
        public void Configure(EntityTypeBuilder<Dinner> builder)
        {
            ConfigureDinnersTable(builder);
            ConfigureReservationsTable(builder);
        }

        private static void ConfigureDinnersTable(EntityTypeBuilder<Dinner> builder)
        {
            builder
                .ToTable("Dinners");

            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => DinnerId.Create(value));

            builder
                .Property(d => d.Name)
                .HasMaxLength(100);

            builder
                .Property(d => d.Description)
                .HasMaxLength(100);

            builder
                .Property(d => d.StartDateTime);

            builder
                .Property(d => d.EndDateTime);

            builder
                .Property(d => d.StartedDateTime)
                .IsRequired(false);

            builder
                .Property(d => d.EndedDateTime)
                .IsRequired(false);

            builder
                .Property(d => d.Status)
                .HasMaxLength(25);

            builder
                .Property(d => d.IsPublic);

            builder
                .Property(d => d.MaxGuests);

            builder
                .OwnsOne(d => d.Price)
                .Property(x => x.Amount)
                .HasColumnType("decimal(18,2)");

            builder
                .Property(d => d.HostId)
                .HasConversion(
                    id => id.Value,
                    value => HostId.Create(value));

            builder
                .Property(d => d.MenuId)
                .HasConversion(
                    id => id.Value,
                    value => MenuId.Create(value));

            builder
                .Property(d => d.ImageUrl);

            builder
                .OwnsOne(d => d.Location);
        }

        private void ConfigureReservationsTable(EntityTypeBuilder<Dinner> builder)
        {
            builder.OwnsMany(d => d.Reservations, rb =>
                {
                    rb.ToTable("Reservations");

                    rb.WithOwner()
                        .HasForeignKey("DinnerId");

                    rb.Property(reservationsBuilder => reservationsBuilder.Id)
                        .ValueGeneratedNever()
                        .HasConversion(
                            id => id.Value,
                            value => ReservationId.Create(value));

                    rb.Property(reservationsBuilder => reservationsBuilder.GuestCount);

                    rb.Property(reservationsBuilder => reservationsBuilder.ReservationStatus);

                    rb.Property(reservationsBuilder => reservationsBuilder.GuestId)
                        .HasConversion(
                            id => id.Value,
                            value => GuestId.Create(value));

                    rb.Property(reservationsBuilder => reservationsBuilder.BillId)
                        .HasConversion(
                            id => id.Value,
                            value => BillId.Create(value));

                    rb.Property(reservationsBuilder => reservationsBuilder.ArrivalDateTime)
                        .IsRequired(false);
                });

            builder.Metadata
                .FindNavigation(nameof(Dinner.Reservations))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
