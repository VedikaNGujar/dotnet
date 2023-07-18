using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.MenuAggregator.ValueObjects
{
    public sealed class MenuId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        public MenuId() { }

        private MenuId(Guid value)
        {
            Value = value;
        }

        public static MenuId Create(Guid value)
        {
            return new MenuId(value);
        }

        public static MenuId CreateUnique()
        {
            return new MenuId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
