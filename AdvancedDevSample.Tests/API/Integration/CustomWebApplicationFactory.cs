
using AdvancedDevSample.Application.Interface;
using AdvancedDevSample.Application.Services;
using AdvancedDevSample.Domain.Interfaces.Products;
using AdvancedDevSample.Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace AdvancedDevSample.Tests.API.Integration
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(IProductRepository));
                services.AddSingleton<IProductRepository, InMemoryProductRepository>();

                services.RemoveAll(typeof(IProductService));
                services.AddScoped<IProductService, ProductService>();
            });
        }
    }
}