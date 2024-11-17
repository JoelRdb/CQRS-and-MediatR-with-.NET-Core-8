using CQRS_and_MediatR.Features.Products.Dtos;
using MediatR;

namespace CQRS_and_MediatR.Features.Products.Queries.List
{
    public record ListProductsQuery : IRequest<List<ProductDto>>;
}
