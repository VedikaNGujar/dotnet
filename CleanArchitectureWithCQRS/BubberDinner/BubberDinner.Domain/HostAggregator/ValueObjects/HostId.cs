using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.HostAggregator.ValueObjects
{
    public sealed class HostId : AggregateRootId<Guid>
    {
        public override Guid Value
        {
            get; protected set;
        }

        private HostId() { }
        private HostId(Guid value)
        {
            Value = value;
        }

        public static HostId Create(Guid value)
        {
            return new HostId(value);
        }

        public static HostId CreateUnique()
        {
            return new HostId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
