using Address.API.Application.Business.Views;
using MediatR;

namespace Address.API.Application.Business.Queries
{
    public class TestQuery:IRequest<AddressView>
    {
    }
    public class TestQueryHandler : IRequestHandler<TestQuery, AddressView>
    {
        public async Task<AddressView> Handle(TestQuery request, CancellationToken cancellationToken)
        {
            return new AddressView{
                Id = Guid.NewGuid(),
                StreetName = "993 Chelsea Blvd",
                City = "Oxford",
                StateCode = "MI",
                PostalCode = "48371",
                CountryCode = "USA"
            };
        }
    }
}
