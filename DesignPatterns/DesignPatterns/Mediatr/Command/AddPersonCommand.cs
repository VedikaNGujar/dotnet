using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Mediatr.Command
{
    public class AddPersonCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }

}
