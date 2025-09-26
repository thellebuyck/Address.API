using Addresses.API.Application.Business.Queries;
using Addresses.API.Application.Business.Views;
using Addresses.API.Application.Data.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Addresses.API.Application.Business.Handlers
{
    public class GetAllAddressesQueryHandler(ApplicationDbContext applicationDbContext) : IRequestHandler<GetAllAddressesQuery, List<AddressView>>
    {
        private readonly ApplicationDbContext applicationDbContext = applicationDbContext;
        public async Task<List<AddressView>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
        {
            var list = new List<AddressView>();
            var addresses = await applicationDbContext.Addresses.ToListAsync(cancellationToken);

            addresses.ForEach((address) =>
            {
                list.Add(new()
                {
                    City = address.City,
                    StateCodeId = address.StateCodeId,
                    StreetName = address.StreetName,
                  
                    Id = address.Id,
                    PostalCode = address.ZipCode
                });

            });
            return list;
        }
    }

}
