﻿using BubberDinner.Domain.BillAggregator.ValueObjects;
using BubberDinner.Domain.DinnerAggregator.ValueObjects;
using BubberDinner.Domain.GuestAggregator.ValueObjects;
using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.DinnerAggregator.Entities
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
