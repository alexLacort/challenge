using PichinchaBank.Domain.Constans;

namespace PichinchaBank.Application.Features.Clients.Queries
{
    public class ClientVm
    {
        public int Id { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public StateType State { get; set; }
    }
}
