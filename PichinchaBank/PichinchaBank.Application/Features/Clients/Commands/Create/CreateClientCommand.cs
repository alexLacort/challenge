using MediatR;

namespace PichinchaBank.Application.Features.Clients.Commands.Create
{
    public class CreateClientCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Identification { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
