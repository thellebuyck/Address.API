﻿using Address.API.Application.Mappings;
using AddressEntity = Address.API.Application.Data.Entities.Address;

namespace Address.API.Application.Business.Views
{
    public class AddressView : IMapFrom<AddressEntity>
    {
        public Guid Id { get; set; }
        public string? StreetName { get; set; }
        public string? City { get; set; }
        public int StateCodeId { get; set; }
        public string? PostalCode { get; set; }
        public string? CountryCode { get; set; }

        public AddressView() { }
    }
}
