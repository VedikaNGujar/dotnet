using DesignPatterns.AppDbModels;
using DesignPatterns.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Mediatr.Command
{
    public class AddPersonCommandHandler(IPersonRepository personRepository)
        : IRequestHandler<AddPersonCommand, int>
    {


        public async Task<int> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                Address = request.Address,
                Name = request.Name,
                Phone = request.Phone
            };
            return await personRepository.AddPerson(person);
        }
    }
}
