using BubberDinner.Domain.Common.Menu.ValueObjects;
using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.Common.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();
        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        public string Name { get; }
        public string Description { get; }

        private MenuSection(MenuSectionId id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
        }

        public static MenuSection Create(string name, string description)
           => new MenuSection(MenuSectionId.CreateUnique(), name, description);
    }
}
