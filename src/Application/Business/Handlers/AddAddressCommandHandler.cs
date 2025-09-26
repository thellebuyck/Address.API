using Addresses.API.Application.Business.Commands;
using Addresses.API.Application.Data.Contexts;
using Addresses.API.Application.Data.Entities;
using MediatR;

namespace Addresses.API.Application.Business.Handlers
{
    public class AddAddressCommandHandler(ApplicationDbContext applicationDbContext) : IRequestHandler<AddAddressCommand, Guid>
    {
        private readonly ApplicationDbContext applicationDbContext = applicationDbContext;
        public async Task<Guid> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Address()
            {
                Id = Guid.NewGuid(),
                City = request.City,
                StateCodeId = request.StateCodeId,
                StreetName = request.StreetName,
                StreetNameExt = request.StreetNameExt,
                ZipCode = request.PostalCode,
                CountryCode = request.Country
            };

            this.applicationDbContext.Addresses.Add(newAddress);
            await this.applicationDbContext.SaveChangesAsync(cancellationToken);

            return newAddress.Id;
        }
    }
}
