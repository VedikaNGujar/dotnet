using BubberDinner.Application.Menus.Commands.CreateMenu;
using BubberDinner.Contracts.Menus;
using BubberDinner.Domain.MenuAggregator;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers
{
    [Route("hosts/{hostId}/[controller]")]
    public class MenusController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public MenusController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenuAsync(CreateMenuRequest request, string hostId)
        {
            Guid guid = Guid.NewGuid();
            //hostId = guid;
            var createMenuCommand = _mapper.Map<CreateMenuCommand>((request, guid));
            ErrorOr<Menu> createMenuResult = await _mediator.Send(createMenuCommand);

            return createMenuResult.Match(
                menu => Ok(_mapper.Map<MenuResponse>(menu)),
                error => Problem(error));

        }
    }
}
