using BubberDinner.Domain.MenuAggregator.ValueObjects;
using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.MenuAggregator.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();
        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        public string Name { get; }
        public string Description { get; }

        private MenuSection() { }

        private MenuSection(MenuSectionId id, string name, string description, List<MenuItem> items) : base(id)
        {
            Name = name;
            Description = description;
            _items = items;
        }

        public static MenuSection Create(string name, string description, List<MenuItem> menuItems)
           => new MenuSection(MenuSectionId.CreateUnique(), name, description, menuItems);
    }
}
