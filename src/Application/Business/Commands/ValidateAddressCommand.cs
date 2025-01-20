using Address.API.Application.Business.Views;
using Address.API.Application.Infrastructure.Services;
using MediatR;

namespace Address.API.Application.Business.Commands
{
    public class ValidateAddressCommand:IRequest<Tuple<AddressView,AddressView>>
    {
        public AddressView UserInput { get; set; }
    }

    public class ValidateAddressCommandHandler(ISmartyStreetService smartyStreetService) : IRequestHandler<ValidateAddressCommand, Tuple<AddressView, AddressView>>
    {
        private readonly ISmartyStreetService smartyStreetService = smartyStreetService;
        public async Task<Tuple<AddressView, AddressView>> Handle(ValidateAddressCommand request, CancellationToken cancellationToken)
        {
            var response = await smartyStreetService.Validate(request.UserInput);
            return response;
        }
    }
}
