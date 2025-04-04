﻿using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.DinnerAggregator.ValueObjects
{
    public sealed class DinnerId : AggregateRootId<Guid>
    {
        public override Guid Value
        {
            get; protected set;
        }

        private DinnerId() { }
        private DinnerId(Guid value)
        {
            Value = value;
        }

        public static DinnerId CreateUnique()
        {
            return new DinnerId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

    }
}
