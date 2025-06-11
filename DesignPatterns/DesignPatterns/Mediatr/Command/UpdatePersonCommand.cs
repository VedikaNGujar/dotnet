using DesignPatterns.AppDbModels;
using MediatR;

namespace DesignPatterns.Mediatr.Command
{
    public class UpdatePersonCommand : IRequest<Person>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
