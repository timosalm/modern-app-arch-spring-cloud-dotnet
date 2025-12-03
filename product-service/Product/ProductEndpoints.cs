using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace ProductService.Product;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/v1/products", (ProductService service) =>
        {
            var products = service.FetchProducts();
            return Results.Ok(products);
        });
    }
}


