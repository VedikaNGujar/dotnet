using BubberDinner.Domain.Common.Menu.Entities;
using BubberDinner.Domain.Common.Menu.ValueObjects;
using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.Common.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        public IReadOnlyList<MenuSection> MenuSections => _sections.AsReadOnly();
        public string Name { get; }
        public string Description { get; }
        public float AverageRating { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Menu(MenuId id, string name, string description, float averageRating, DateTime createdDateTime, DateTime updatedDateTime) : base(id)
        {
            Name = name;
            Description = description;
            AverageRating = averageRating;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Menu Create(string name, string description, float averageRating, DateTime createdDateTime, DateTime updatedDateTime)
           => new Menu(MenuId.CreateUnique(), name, description, averageRating, createdDateTime, updatedDateTime);
    }
}
