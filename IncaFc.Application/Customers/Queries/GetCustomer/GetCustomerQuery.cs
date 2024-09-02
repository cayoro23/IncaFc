using ErrorOr;

using IncaFc.Domain.CustomerAggregate;

using MediatR;

namespace IncaFc.Application.Customers.Queries.GetCustomer;

public record GetCustomerQuery(Guid CustomerId) : IRequest<ErrorOr<Customer>>;