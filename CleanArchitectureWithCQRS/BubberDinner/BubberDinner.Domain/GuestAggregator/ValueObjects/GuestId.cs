using BubberDinner.Domain.DinnerAggregator.ValueObjects;
using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.GuestAggregator.ValueObjects
{
    public sealed class GuestId : ValueObject
    {
        public Guid Value { get; }

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
    }
}
