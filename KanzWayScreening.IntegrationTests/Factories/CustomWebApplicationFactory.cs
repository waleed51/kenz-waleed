using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace KanzWayScreening.IntegrationTests.Factories;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");

        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IMediator));
            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            // Add a mocked IMediator
            var mediatorMock = new Mock<IMediator>();
            services.AddSingleton(mediatorMock.Object);
        });
    }
}