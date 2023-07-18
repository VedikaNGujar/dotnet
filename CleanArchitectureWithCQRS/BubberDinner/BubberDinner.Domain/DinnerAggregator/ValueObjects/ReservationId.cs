using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.DinnerAggregator.ValueObjects
{
    public sealed class ReservationId : ValueObject
    {
        public Guid Value { get; private set; }

        public ReservationId() { }

        private ReservationId(Guid value)
        {
            Value = value;
        }

        public static ReservationId CreateUnique()
        {
            return new ReservationId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static ReservationId Create(Guid value)
        {
            return new(value);

        }
    }
}
