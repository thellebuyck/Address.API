using Address.API.Application.Business.Commands;
using Address.API.Application.Business.Queries;
using Address.API.Application.Business.Views;
using Address.API.Application.Common.Exceptions;
using Address.API.Application.Data.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Address.API.Application.Business.Handlers
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
