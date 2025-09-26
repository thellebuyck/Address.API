using Addresses.API.Application.Business.Commands;
using FluentValidation;

namespace Addresses.API.Application.Business.Validators
{
    public class AddAddressCommandValidator:AbstractValidator<AddAddressCommand>
    {
        public AddAddressCommandValidator()
        {
            RuleFor(c => c.StreetName).NotEmpty().WithMessage("A Street Name is required");
            RuleFor(c => c.City).NotEmpty().WithMessage("A City is required");
            RuleFor(c => c.PostalCode).NotEmpty().WithMessage("A Postal Code is required");
            RuleFor(c => c.StateCodeId).NotEmpty().GreaterThan(0).WithMessage("A State Code is required");
            RuleFor(c => c.Country).NotEmpty().WithMessage("A Country is required");
        }
    }
}
