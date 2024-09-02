using ErrorOr;

using IncaFc.Application.Common.Interfaces.Persistence;
using IncaFc.Domain.CustomerAggregate;

using MediatR;

namespace IncaFc.Application.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ErrorOr<Customer>>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<ErrorOr<Customer>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Crear Producto
        var customer = Customer.Create(
            name: request.Name
        );

        // Persistir Producto
        _customerRepository.Add(customer);

        // Retornar Producto
        return customer;
    }
}
