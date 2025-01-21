using Address.API.Application.Business.Views;
using MediatR;

namespace Address.API.Application.Business.Queries
{
    public class GetAddressByIdQuery:IRequest<AddressView>
    {
        public Guid Id { get; set; }
    }
}
