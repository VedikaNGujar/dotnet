using DesignPatterns.AppDbModels;
using DesignPatterns.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Mediatr.Command
{
    public class DeletePersonCommandHandler(IPersonRepository personRepository)
        : IRequestHandler<DeletePersonCommand, Unit>
    {


        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            await personRepository.DeletePerson(request.Id);
            return Unit.Value;
        }
    }
}
