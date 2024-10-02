//using Microsoft.AspNetCore.Mvc.Testing;
//using System.Net;

//namespace KanzWayScreening.IntegrationTests
//{
//    public class ScreeningControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
//    {
//        private readonly HttpClient _client;

//        public ScreeningControllerIntegrationTests(WebApplicationFactory<Program> factory)
//        {
//            _client = factory.CreateClient();
//        }

//        [Theory]
//        [InlineData(3, "Kanz")]
//        [InlineData(5, "Way")]
//        [InlineData(15, "KanzWay")]
//        [InlineData(7, "7")]
//        public async Task GetScreeningResult_ShouldReturnExpectedResult(int number, string expected)
//        {
//            // Arrange
//            var url = $"/api/v1/screening/{number}";

//            // Act
//            var response = await _client.GetAsync(url);

//            // Assert
//            response.StatusCode.Should().Be(HttpStatusCode.OK);

//            var content = await response.Content.ReadAsStringAsync();
//            content.Should().Contain(expected);
//        }
//    }
//}
