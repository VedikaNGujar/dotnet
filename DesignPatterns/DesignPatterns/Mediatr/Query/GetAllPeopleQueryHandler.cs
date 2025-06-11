using DesignPatterns.AppDbModels;
using DesignPatterns.Repository;
using MediatR;

namespace DesignPatterns.Mediatr.Query
{
    public class GetAllPeopleQueryHandler(IPersonRepository personRepository) : IRequestHandler<GetAllPersonQuery, List<Person>>
    {
        public async Task<List<Person>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        {
            return await personRepository.GetPeople();
        }
    }
}
