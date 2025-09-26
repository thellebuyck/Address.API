using AddressEntity = Addresses.API.Application.Data.Entities.Address;

namespace Addresses.API.Application.Business.Views
{
    public class AddressView 
    {
        public Guid Id { get; set; }
        public string? StreetName { get; set; }
        public string? StreetNameExt { get; set; }
        public string? City { get; set; }
        public int StateCodeId { get; set; }
        public string? StateCodeName { get; set; }
        public string? PostalCode { get; set; }

        public AddressView() { }
    }
}
