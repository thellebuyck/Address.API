namespace Addresses.API.Application.Data.Entities
{
    public class StateCode
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        //Navigation property
        public IList<Address>? Addresses { get; set; }
    }
}
