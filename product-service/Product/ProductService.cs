using Microsoft.Extensions.Options;

namespace ProductService.Product;

public sealed class ProductService(IOptions<ProductServiceOptions> options)
{
    private readonly ProductServiceOptions _options = options.Value;

    public List<Product> FetchProducts()
    {
        var id = 1;

        return _options.ProductNames
            .Select(name => new Product
            {
                Id = id++,
                Name = name
            })
            .ToList();
    }
}


