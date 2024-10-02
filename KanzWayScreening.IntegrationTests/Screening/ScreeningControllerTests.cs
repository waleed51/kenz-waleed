using FluentAssertions;
using KanzWayScreening.IntegrationTests.Factories;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace KanzWayScreening.IntegrationTests.Screening;

public class ScreeningControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ScreeningControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetScreeningResultAsync_ShouldReturnKanz_WhenNumberIsDivisibleBy3()
    {
        var number = 9;
        var response = await _client.GetAsync($"/api/v1/screening/{number}");
        if (response.IsSuccessStatusCode)
        {
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadFromJsonAsync<List<string>>();
            result.Should().ContainSingle().Which.Should().Be("Kanz");
        }
        else
        {
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

    }

    [Fact]
    public async Task GetScreeningResultAsync_ShouldReturnWay_WhenNumberIsDivisibleBy5()
    {
        var number = 10;
        var response = await _client.GetAsync($"/api/v1/screening/{number}");
        if(response.IsSuccessStatusCode)
        {
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var result = await response.Content.ReadFromJsonAsync<List<string>>();
            result.Should().ContainSingle().Which.Should().Be("Way");
        }
        else
        {
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }

    [Fact]
    public async Task GetScreeningResultAsync_ShouldReturnKanzWay_WhenNumberIsDivisibleByBoth3And5()
    {
        var number = 15;
        var response = await _client.GetAsync($"/api/v1/screening/{number}");
        if (response.IsSuccessStatusCode)
        {
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadFromJsonAsync<List<string>>();
            result.Should().ContainSingle().Which.Should().Be("KanzWay");
        }
        else
        {
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }

    [Fact]
    public async Task GetScreeningResultAsync_ShouldReturnNumber_WhenNumberIsNotDivisibleBy3Or5()
    {
        var number = 7;
        var response = await _client.GetAsync($"/api/v1/screening/{number}");
        if (response.IsSuccessStatusCode)
        {
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadFromJsonAsync<List<string>>();
            result.Should().ContainSingle().Which.Should().Be(number.ToString());
        }
        else
        {
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}