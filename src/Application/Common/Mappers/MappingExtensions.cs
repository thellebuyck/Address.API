using Addresses.API.Application.Business.Views;
using Addresses.API.Application.Data.Entities;

namespace Addresses.API.Application.Common.Mappers
{
    public static class MappingExtensions
    {
        public static AddressView AddressView(this Data.Entities.Address address) =>
            new()
            {
                Id = address.Id,
                StreetName = address.StreetName,
                StreetNameExt = address.StreetNameExt,
                City = address.City,
                StateCodeId = address.StateCodeId,
                StateCodeName = address.StateCode?.Name,
                PostalCode = address.ZipCode
            };

        public static Address GetAddress(this AddressView addressView) =>
            new()
            {
                Id = addressView.Id,
                StreetName = addressView.StreetName,
                StreetNameExt = addressView.StreetNameExt,
                City = addressView.City,
                StateCodeId = addressView.StateCodeId,
                ZipCode = addressView.PostalCode
            };
    }
}
