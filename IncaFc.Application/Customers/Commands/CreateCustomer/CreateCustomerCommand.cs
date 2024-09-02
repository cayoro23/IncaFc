using ErrorOr;

using IncaFc.Domain.CustomerAggregate;

using MediatR;

namespace IncaFc.Application.Customers.Commands.CreateCustomer;

public record CreateCustomerCommand(string Name) :
    IRequest<ErrorOr<Customer>>;
