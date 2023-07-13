using BubberDinner.Domain.Common.Bill.ValueObjects;
using BubberDinner.Domain.Common.Dinner.ValueObjects;
using BubberDinner.Domain.Common.Guest.ValueObjects;
using BubberDinner.Domain.Common.Host.ValueObjects;
using BubberDinner.Domain.Models;
using System.Diagnostics;

namespace BubberDinner.Domain.Common.Bill
{
    public sealed class Bill : AggregateRoot<BillId>
    {
        public DinnerId DinnerId { get; }
        public GuestId GuestId { get; }
        public HostId HostId { get; }
        public Price Price { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Bill(
            BillId id,
            GuestId guestId,
            HostId hostId,
            Price price,
            DateTime createdDateTime,
            DateTime updatedDateTime)
            : base(id)
        {
            GuestId = guestId;
            HostId = hostId;
            Price = price;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Bill Create(
            GuestId guestId,
            HostId hostId,
            Price price)
        {
            return new(
                BillId.CreateUnique(),
                guestId,
                hostId,
                price,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
