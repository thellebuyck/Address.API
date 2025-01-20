namespace Address.API.Application.Business.Views
{
    public class AddressView
    {
        public Guid Id { get; set; }
        public string? StreetName { get; set; }
        public string? City { get; set; }
        public string? StateCode { get; set; }
        public string? PostalCode { get; set; }
        public string? CountryCode { get; set; }
    }
}
