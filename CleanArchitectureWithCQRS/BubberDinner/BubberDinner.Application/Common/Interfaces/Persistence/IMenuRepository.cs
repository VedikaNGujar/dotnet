using BubberDinner.Domain.MenuAggregator;

namespace BubberDinner.Application.Common.Interfaces.Persistence
{
    public interface IMenuRepository
    {
        void Add(Menu menu);
    }
}
