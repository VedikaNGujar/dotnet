using BubberDinner.Domain.MenuAggregator;
using ErrorOr;
using MediatR;

namespace BubberDinner.Application.Menus.Commands.CreateMenu
{
    public record CreateMenuCommand(
        Guid HostId,
        string Name,
        string Description,
        float AverageRating,
        List<MenuSectionCommand> Sections) : IRequest<ErrorOr<Menu>>;

    public record MenuSectionCommand(
        string Name,
        string Description,
        List<MenuItemCommand> Items);

    public record MenuItemCommand(
        string Name,
        string Description);
}
