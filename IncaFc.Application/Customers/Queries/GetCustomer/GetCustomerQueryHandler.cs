using ErrorOr;

using IncaFc.Application.Common.Interfaces.Persistence;
using IncaFc.Application.Customers.Queries.GetCustomer;
using IncaFc.Domain.CustomerAggregate;
using IncaFc.Domain.ProductAggregate;

using MediatR;

namespace IncaFc.Application.Products.Queries.GetProduct;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, ErrorOr<Customer>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<ErrorOr<Customer>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        // Buscar el producto por ID
        var customer = await _customerRepository.GetByIdInMemoryAsync(request.CustomerId);

        // Verificar si el producto existe
        if (customer is null)
        {
            return Error.NotFound($"Customer with ID {request.CustomerId} not found.");
        }

        // Retornar el producto encontrado
        return customer;
    }
}
