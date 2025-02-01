using ERPServer.Application.Features.Depots.CreateDepot;
using FluentValidation;

namespace ERPServer.Application.Features.Customers.CreateCustomer;

public sealed class CreateDepotCommandValidator : AbstractValidator<CreateDepotCommand>
{
    public CreateDepotCommandValidator()
    {
        //RuleFor(p => p.TaxNumber).MinimumLength(10).MaximumLength(11);
        RuleFor(p => p.Name).MinimumLength(3);
    }
}
