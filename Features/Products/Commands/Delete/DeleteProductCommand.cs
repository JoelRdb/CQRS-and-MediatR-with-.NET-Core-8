using MediatR;

namespace CQRS_and_MediatR.Features.Products.Commands.Delete
{
    public record DeleteProductCommand(Guid Id) : IRequest;

}
