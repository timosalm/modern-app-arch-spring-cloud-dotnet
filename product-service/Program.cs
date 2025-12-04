using Microsoft.Extensions.Options;

using Steeltoe.Common.Logging;
using Steeltoe.Configuration.ConfigServer;
using Steeltoe.Configuration.CloudFoundry;
using Steeltoe.Configuration.CloudFoundry.ServiceBindings;
using Steeltoe.Discovery.Eureka;

using ProductService.Product;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ProductServiceOptions>(
    builder.Configuration.GetSection(key: nameof(ProductServiceOptions)));

builder.Services.AddScoped<ProductService.Product.ProductService>();

var loggerFactory = BootstrapLoggerFactory.CreateConsole();

builder.AddCloudFoundryConfiguration(loggerFactory);
builder.Configuration.AddCloudFoundryServiceBindings();
builder.Services.AddEurekaDiscoveryClient();

builder.Configuration.AddConfigServer(loggerFactory);
builder.Services.UpgradeBootstrapLoggerFactory(loggerFactory);


var app = builder.Build();

app.MapProductEndpoints();

app.Run();