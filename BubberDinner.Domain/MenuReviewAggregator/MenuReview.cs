using BubberDinner.Domain.Common.ValueObjects;
using BubberDinner.Domain.DinnerAggregator.ValueObjects;
using BubberDinner.Domain.GuestAggregator.ValueObjects;
using BubberDinner.Domain.HostAggregator.ValueObjects;
using BubberDinner.Domain.MenuAggregator.ValueObjects;
using BubberDinner.Domain.MenuReviewAggregator.ValueObjects;
using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.MenuReviewAggregator
{
    public sealed class MenuReview : AggregateRoot<MenuReviewId, Guid>
    {
        public Rating Rating { get; private set; }
        public string Comment { get; private set; }
        public HostId HostId { get; private set; }
        public MenuId MenuId { get; private set; }
        public GuestId GuestId { get; private set; }
        public DinnerId DinnerId { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

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

        private MenuReview() { }

    }
}
