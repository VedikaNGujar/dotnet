using DesignPatterns.AppDbModels;
using MediatR;

namespace DesignPatterns.Mediatr.Query
{
    public class GetPersonByIdQuery : IRequest<Person>
    {
        public int Id { get; set; }
    }
}
