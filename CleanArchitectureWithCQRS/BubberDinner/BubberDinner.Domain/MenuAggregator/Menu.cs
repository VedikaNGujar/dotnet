using BubberDinner.Domain.Common.ValueObjects;
using BubberDinner.Domain.DinnerAggregator.ValueObjects;
using BubberDinner.Domain.HostAggregator.ValueObjects;
using BubberDinner.Domain.MenuAggregator.Entities;
using BubberDinner.Domain.MenuAggregator.ValueObjects;
using BubberDinner.Domain.MenuReviewAggregator.ValueObjects;
using BubberDinner.Domain.Models;

namespace BubberDinner.Domain.MenuAggregator
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();

        public IReadOnlyList<MenuSection> MenuSections => _sections.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();


        public string Name { get; }
        public string Description { get; }
        public AverageRating AverageRating { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
        public HostId HostId { get; private set; }


        private Menu(
         MenuId menuId,
         HostId hostId,
         string name,
         string description,
         AverageRating averageRating,
         List<MenuSection>? sections)
         : base(menuId)
        {
            HostId = hostId;
            Name = name;
            Description = description;
            _sections = sections ?? new();
            AverageRating = averageRating;
        }

        public static Menu Create(
            HostId hostId,
            string name,
            string description,
            List<MenuSection>? sections = null)
        {
            var menu = new Menu(
                MenuId.CreateUnique(),
                hostId,
                name,
                description,
                AverageRating.CreateNew(0),
                sections ?? new());

            return menu;
        }
    }
}
