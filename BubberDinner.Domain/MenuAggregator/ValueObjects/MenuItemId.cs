﻿using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.MenuAggregator.ValueObjects
{
    public sealed class MenuItemId : ValueObject
    {
        public Guid Value { get; }
        private MenuItemId() { }

        private MenuItemId(Guid value)
        {
            Value = value;
        }

        public static MenuItemId CreateUnique()
        {
            return new MenuItemId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static MenuItemId Create(Guid value)
        {
            return new MenuItemId(value);

        }
    }
}
