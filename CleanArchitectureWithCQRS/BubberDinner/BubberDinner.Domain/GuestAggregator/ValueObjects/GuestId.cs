using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.GuestAggregator.ValueObjects
{
    public sealed class GuestId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        public GuestId() { }

        private GuestId(Guid value)
        {
            Value = value;
        }

        public static GuestId CreateUnique()
        {
            return new GuestId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static GuestId Create(Guid value)
        {
            return new GuestId(value);
        }
    }
}
