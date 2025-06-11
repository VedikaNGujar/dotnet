using DesignPatterns.AppDbModels;
using DesignPatterns.DTO;
using DesignPatterns.Mediatr.Command;
using DesignPatterns.Mediatr.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers.Mediatr
{
    [ApiController]
    [Route("[controller]")]
    public class PersonMediatrController(IMediator mediator) : ControllerBase
    {

        [HttpGet]
        [Route("getAllPeople")]
        public async Task<IActionResult> GetPeople()
        {
            return Ok(await mediator.Send(new GetAllPersonQuery()));

        }

        [HttpGet]
        [Route("getPersonById/{id:int}")]
        public async Task<IActionResult> GetPeopleById(int id)
        {
            var result = await mediator.Send(new GetPersonByIdQuery() { Id = id });
            if (result == null)
                return NotFound();
            return Ok(result);

        }

        [HttpPost]
        [Route("addPerson")]
        public async Task<IActionResult> AddPersonAsync([FromBody] PersonDTO person)
        {
            var id = await mediator.Send(
                new AddPersonCommand
                {
                    Address = person.Address,
                    Name = person.Name,
                    Phone = person.Phone
                });

            return CreatedAtAction(nameof(GetPeopleById), new { id = id }, id);

        }

        [HttpPut]
        [Route("updatePerson/{id:int}")]
        public async Task<IActionResult> UpdatePersonAsync(int id, [FromBody] PersonDTO person)
        {
            var result = await mediator.Send(
                new UpdatePersonCommand
                {
                    Id = id,
                    Address = person.Address,
                    Name = person.Name,
                    Phone = person.Phone
                });
            if (result == null)
                return NotFound();
            else
                return CreatedAtAction(nameof(GetPeopleById), new { id = id }, result);

        }

        [HttpDelete]
        [Route("deletePerson/{id:int}")]
        public async Task<IActionResult> DeletePersonAsync(int id)
        {
            await mediator.Send(new DeletePersonCommand() { Id = id });
            return NoContent();

        }
    }
}
