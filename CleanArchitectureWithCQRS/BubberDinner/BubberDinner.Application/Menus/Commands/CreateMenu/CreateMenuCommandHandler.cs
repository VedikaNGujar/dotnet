using BubberDinner.Application.Common.Interfaces.Persistence;
using BubberDinner.Application.Common.Services;
using BubberDinner.Domain.HostAggregator.ValueObjects;
using BubberDinner.Domain.MenuAggregator;
using BubberDinner.Domain.MenuAggregator.Entities;
using ErrorOr;
using MediatR;

namespace BubberDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IMenuRepository _menuRepository;

        public CreateMenuCommandHandler(IDateTimeProvider dateTimeProvider, IMenuRepository menuRepository)
        {
            _dateTimeProvider = dateTimeProvider;
            _menuRepository = menuRepository;
        }

        public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request,
            CancellationToken cancellationToken)
        {
            var menu = Menu.Create(
                HostId.Create(request.HostId),
                request.Name,
                request.Description,
                request.Sections.ConvertAll(section =>
                MenuSection.Create(
                    section.Name,
                    section.Description,
                    section.Items.ConvertAll(item => MenuItem.Create(item.Name, item.Description)))));

            _menuRepository.Add(menu);

            return await Task.FromResult(menu);
        }
    }
}
