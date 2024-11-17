using CQRS_and_MediatR.Persistence;
using MediatR;

namespace CQRS_and_MediatR.Features.Products.Commands.Update
{
    public class UpdateProductCommandHandler(AppDbContext context) : IRequestHandler<UpdateProductCommand, bool>
    {
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FindAsync(request.Id);
            if (product == null) return false;

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;

            context.Products.Update(product);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
