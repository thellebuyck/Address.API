using Address.API.Application.Business.Views;
using MediatR;

namespace Address.API.Application.Business.Queries
{
    public class GetAllAddressesQuery : IRequest<List<AddressView>>
    {
    }

}
