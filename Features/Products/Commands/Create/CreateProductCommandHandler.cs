using CQRS_and_MediatR.Domain;
using CQRS_and_MediatR.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_and_MediatR.Features.Products.Commands.Create
{
    public class CreateProductCommandHandler(AppDbContext context) : IRequestHandler<CreateProductCommand, Guid>
    {
        public async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product(command.Name, command.Description, command.Price);
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return product.Id;
        }
    }
}
