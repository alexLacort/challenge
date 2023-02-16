using MediatR;

namespace PichinchaBank.Application.Features.Clients.Commands.Delete
{
    public class DeleteClientCommand : IRequest
    {
        public string Identification { get; set; }
    }
}
