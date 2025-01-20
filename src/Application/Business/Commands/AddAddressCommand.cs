using MediatR;

namespace Address.API.Application.Business.Commands
{
    public class AddAddressCommand:IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string? StreetName { get; set; }
        public string? StreetNameExt { get;set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public int StateCodeId { get; set; }
        public string? Country { get; set; }

    }
}
