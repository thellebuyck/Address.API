using Addresses.API.Application.Business.Views;
using MediatR;

namespace Addresses.API.Application.Business.Queries
{
    public class GetAllAddressesQuery : IRequest<List<AddressView>>
    {
    }

}
