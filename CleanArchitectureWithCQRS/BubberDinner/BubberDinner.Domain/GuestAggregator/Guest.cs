using BubberDinner.Domain.GuestAggregator.ValueObjects;
using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.GuestAggregator
{
    public sealed class Guest : AggregateRoot<GuestId>
    {
        public Guest(GuestId id) : base(id)
        {
        }
    }
}
