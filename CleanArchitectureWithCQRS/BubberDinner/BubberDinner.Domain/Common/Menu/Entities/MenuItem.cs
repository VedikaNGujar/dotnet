using BubberDinner.Domain.Common.Menu.ValueObjects;
using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.Common.Menu.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        public string Name { get; }
        public string Description { get; }

        private MenuItem(MenuItemId id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
        }

        public static MenuItem Create(string name, string description)
            => new MenuItem(MenuItemId.CreateUnique(), name, description);
    }
}
