using DesignPatterns.AppDbModels;
using DesignPatterns.Repository;
using MediatR;

namespace DesignPatterns.Mediatr.Query
{
    public class GetPersonByIdQueryHandler(IPersonRepository personRepository)
        : IRequestHandler<GetPersonByIdQuery, Person>
    {
        public async Task<Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            return await personRepository.GetPersonById(request.Id);
        }
    }
}
