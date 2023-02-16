using MediatR;
using PichinchaBank.Domain.Constans;
using System.ComponentModel.DataAnnotations;

namespace PichinchaBank.Application.Features.Clients.Commands.Update
{
    public class UpdateClientCommand : IRequest
    {
        public string Identification { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string Password { get; set; }
        public StateType State { get; set; }
    }
}
