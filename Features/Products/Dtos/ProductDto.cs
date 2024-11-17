namespace CQRS_and_MediatR.Features.Products.Dtos
{
   public record ProductDto(Guid Id, string Name, string Description, decimal Price);  
}
