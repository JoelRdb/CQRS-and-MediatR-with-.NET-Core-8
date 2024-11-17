using MediatR;

namespace CQRS_and_MediatR.Features.Products.Commands.Update
{
    public record UpdateProductCommand(Guid Id, string Name, string Description, decimal Price) : IRequest<bool>;
}
