using Addresses.API.Application.Business.Commands;
using Addresses.API.Application.Business.Queries;
using Addresses.API.Application.Business.Views;
using Addresses.API.Application.Common.Exceptions;
using Addresses.API.Application.Data.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Addresses.API.Application.Data.Entities;


namespace Addresses.API.Application.Business.Handlers
{
    public class GetAddressByQueryHandler(ApplicationDbContext context) : IRequestHandler<GetAddressByIdQuery, AddressView>
    {
        private readonly ApplicationDbContext applicationDbContext = context;
        public async Task<AddressView> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var existingAddress = await this.applicationDbContext.Addresses
                .Where(a => a.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (existingAddress == null)
            {
                throw new NotFoundException($"Unable to locate address by Id: {request.Id}");
            }

            return new AddressView
            {
                Id = existingAddress.Id,
                StreetName = existingAddress.StreetName,
                City = existingAddress.City,
                StateCodeId = existingAddress.StateCodeId,
                CountryCode = existingAddress.CountryCode,
                PostalCode = existingAddress.ZipCode
            };
        }
    }
}
