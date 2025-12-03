using Microsoft.Extensions.Options;
using Steeltoe.Configuration.ConfigServer;
using ProductService.Product;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ProductServiceOptions>(
    builder.Configuration.GetSection(key: nameof(ProductServiceOptions)));

builder.Services.AddScoped<ProductService.Product.ProductService>();

builder.Configuration.AddConfigServer();

var app = builder.Build();

app.MapProductEndpoints();

app.Run();