namespace Address.API.Application.Data.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public int StateCodeId { get; set; }
        public string? StreetName { get; set; }
        public string? StreetNameExt { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? CountryCode { get; set; }
        
    }
}
