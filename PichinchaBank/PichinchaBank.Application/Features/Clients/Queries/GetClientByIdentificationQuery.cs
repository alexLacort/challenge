using MediatR;

namespace PichinchaBank.Application.Features.Clients.Queries
{
    public class GetClientByIdentificationQuery : IRequest<ClientVm>
    {
        public string ClientIdentification { get; set; } = string.Empty;
        public GetClientByIdentificationQuery(string identification)
        {
            ClientIdentification = identification ?? throw new ArgumentNullException(nameof(identification));
        }
    }
}
