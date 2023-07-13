using BubberDinner.Domain.Common.Guest.ValueObjects;
using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.Common.Guest
{
    public sealed class Guest : AggregateRoot<GuestId>
    {
        public Guest(GuestId id) : base(id)
        {
        }
    }
}
