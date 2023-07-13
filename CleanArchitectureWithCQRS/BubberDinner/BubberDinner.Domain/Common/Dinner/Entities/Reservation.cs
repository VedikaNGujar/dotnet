using BubberDinner.Domain.Common.Bill.ValueObjects;
using BubberDinner.Domain.Common.Dinner.ValueObjects;
using BubberDinner.Domain.Common.Guest.ValueObjects;
using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.Common.Dinner.Entities
{
    public sealed class Reservation : Entity<ReservationId>
    {
        public int GuestCount { get; }
        public string ReservationStatus { get; }
        public GuestId GuestId { get; }
        public BillId BillId { get; }
        public DateTime? ArrivalDateTime { get; private set; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Reservation(
        ReservationId reservationId,
        int guestCount,
        string reservationStatus,
        GuestId guestId,
        BillId billId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    : base(reservationId)
        {
            GuestCount = guestCount;
            ReservationStatus = reservationStatus;
            GuestId = guestId;
            BillId = billId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Reservation Create(
            int guestCount,
            string reservationStatus,
            GuestId guestId,
            BillId billId
            )
        {
            return new(
                ReservationId.CreateUnique(),
                guestCount,
                reservationStatus,
                guestId,
                billId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
