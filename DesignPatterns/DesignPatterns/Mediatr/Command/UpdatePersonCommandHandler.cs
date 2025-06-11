using DesignPatterns.AppDbModels;
using DesignPatterns.Repository;
using MediatR;

namespace DesignPatterns.Mediatr.Command
{
    public class UpdatePersonCommandHandler(IPersonRepository personRepository) : IRequestHandler<UpdatePersonCommand, Person>
    {
        public async Task<Person> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            return await personRepository.UpdatePerson(
                new Person { Address = request.Address, Id = request.Id, Name = request.Name, Phone = request.Phone });
        }
    }
}
