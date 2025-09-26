using Addresses.API.Application.Business.Views;
using MediatR;

namespace Addresses.API.Application.Business.Queries
{
    public class GetAddressByIdQuery:IRequest<AddressView>
    {
        public Guid Id { get; set; }
    }
}
