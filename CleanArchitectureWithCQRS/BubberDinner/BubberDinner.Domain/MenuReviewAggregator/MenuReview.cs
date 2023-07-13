using BubberDinner.Domain.Common.ValueObjects;
using BubberDinner.Domain.DinnerAggregator.ValueObjects;
using BubberDinner.Domain.GuestAggregator.ValueObjects;
using BubberDinner.Domain.HostAggregator.ValueObjects;
using BubberDinner.Domain.MenuAggregator.ValueObjects;
using BubberDinner.Domain.MenuReviewAggregator.ValueObjects;
using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.MenuReviewAggregator
{
    public sealed class MenuReview : AggregateRoot<MenuReviewId>
    {
        public Rating Rating { get; }
        public string Comment { get; }
        public HostId HostId { get; }
        public MenuId MenuId { get; }
        public GuestId GuestId { get; }
        public DinnerId DinnerId { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private MenuReview(
            MenuReviewId menuReviewId,
            string comment,
            HostId hostId,
            MenuId menuId,
            GuestId guestId,
            DinnerId dinnerId,
            DateTime createdDateTime,
            DateTime updatedDateTime)
            : base(menuReviewId)
        {
            Comment = comment;
            HostId = hostId;
            MenuId = menuId;
            GuestId = guestId;
            DinnerId = dinnerId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static MenuReview Create(
            string comment,
            HostId hostId,
            MenuId menuId,
            GuestId guestId,
            DinnerId dinnerId)
        {
            return new(
                MenuReviewId.CreateUnique(),
                comment,
                hostId,
                menuId,
                guestId,
                dinnerId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

    }
}
