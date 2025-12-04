using Steeltoe.Common.Logging;
using Steeltoe.Configuration.ConfigServer;
using Steeltoe.Configuration.CloudFoundry.ServiceBindings;
using Steeltoe.Discovery.Eureka;

using ProductService.Product;

var builder = WebApplication.CreateBuilder(args);

var loggerFactory = BootstrapLoggerFactory.CreateConsole(logging => logging.AddConfiguration(builder.Configuration));
builder.AddConfigServer(loggerFactory);
builder.Configuration.AddCloudFoundryServiceBindings();

builder.Services.Configure<ProductServiceOptions>(
    builder.Configuration.GetSection(key: nameof(ProductServiceOptions)));

builder.Services.AddScoped<ProductService.Product.ProductService>();

builder.Services.AddEurekaDiscoveryClient();

builder.Services.UpgradeBootstrapLoggerFactory(loggerFactory);


var app = builder.Build();

app.MapProductEndpoints();

app.Run();