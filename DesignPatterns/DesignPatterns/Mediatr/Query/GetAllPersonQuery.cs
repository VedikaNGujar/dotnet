using DesignPatterns.AppDbModels;
using MediatR;

namespace DesignPatterns.Mediatr.Query
{
    public class GetAllPersonQuery : IRequest<List<Person>>
    {
    }


}
