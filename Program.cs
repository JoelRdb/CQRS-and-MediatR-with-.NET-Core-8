
using CQRS_and_MediatR.Features.Products.Commands.Create;
using CQRS_and_MediatR.Features.Products.Commands.Delete;
using CQRS_and_MediatR.Features.Products.Commands.Update;
using CQRS_and_MediatR.Features.Products.Queries.Get;
using CQRS_and_MediatR.Features.Products.Queries.List;
using CQRS_and_MediatR.Persistence;
using MediatR;
using System.Reflection;

namespace CQRS_and_MediatR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapGet("/products/{id:guid}", async (Guid id, ISender mediatr) =>
            {
                var product = await mediatr.Send(new GetProductQuery(id));
                if (product == null) return Results.NotFound();
                return Results.Ok(product);
            });

            app.MapGet("/products", async (ISender mediatr) =>
            {
                var products = await mediatr.Send(new ListProductsQuery());
                return Results.Ok(products);
            });

            app.MapPost("/products", async (CreateProductCommand command, ISender mediatr) =>
            {
                var productId = await mediatr.Send(command);
                if (Guid.Empty == productId) return Results.BadRequest();
                return Results.Created($"/products/{productId}", new { id = productId });
            });

            app.MapDelete("/products/{id:guid}", async (Guid id, ISender mediatr) =>
            {
                await mediatr.Send(new DeleteProductCommand(id));
                return Results.NoContent();
            });

            app.MapPut("/products/{id:guid}", async (Guid id, UpdateProductCommand command, ISender mediatr) =>
            {
                var productUpdated = await mediatr.Send(command);              
                return Results.NoContent();

            });

            app.MapControllers();

            app.Run();
        }
    }
}