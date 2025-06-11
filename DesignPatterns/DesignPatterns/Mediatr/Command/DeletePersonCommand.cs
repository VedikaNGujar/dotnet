using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Mediatr.Command
{
    public class DeletePersonCommand() : IRequest<Unit>
    {
        public int Id { get; set; }
    }

}
