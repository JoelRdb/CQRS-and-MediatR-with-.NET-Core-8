using CQRS_and_MediatR.Features.Products.Dtos;
using CQRS_and_MediatR.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_and_MediatR.Features.Products.Queries.List
{
    public class ListProductsQueryHandler(AppDbContext context) : IRequestHandler<ListProductsQuery, List<ProductDto>> // IRequestHandler<T, R> où T est la requete entrante et R serait la réponse
    {
        public async Task<List<ProductDto>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
        {
            return await context.Products
                .Select(p => new ProductDto(p.Id, p.Name, p.Description, p.Price))
                .ToListAsync();
        }
    }
}
