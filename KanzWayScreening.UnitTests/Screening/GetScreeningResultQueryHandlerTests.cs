using FluentAssertions;
using KanzWayScreening.Application.Screening.Interfaces;
using KanzWayScreening.Application.Screening.Queries;
using KanzWayScreening.Application.Screening.Queries.Dtos;
using Moq;
using Xunit;

namespace KanzWayScreening.UnitTests.Screening;
public class GetScreeningResultQueryHandlerTests
{
    private readonly Mock<IScreeningQueryManager> _mockScreeningQueryManager;
    private readonly GetScreeningResultQueryHandler _handler;

    public GetScreeningResultQueryHandlerTests()
    {
        _mockScreeningQueryManager = new Mock<IScreeningQueryManager>();
        _handler = new GetScreeningResultQueryHandler(_mockScreeningQueryManager.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnKanz_WhenNumberIsDivisibleBy3()
    {
        var query = new GetScreeningResultQuery { Number = 9 };
        var expectedResult = new ScreeningResultDto{Results = new List<string> { "Kanz" }};

        _mockScreeningQueryManager
            .Setup(m => m.GetResultAsync(query.Number))
            .ReturnsAsync(expectedResult);

        var result = await _handler.Handle(query, CancellationToken.None);

        result.Should().BeEquivalentTo(expectedResult);
        _mockScreeningQueryManager.Verify(m => m.GetResultAsync(query.Number), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldReturnWay_WhenNumberIsDivisibleBy5()
    {
        var query = new GetScreeningResultQuery { Number = 10 };
        var expectedResult = new ScreeningResultDto { Results = new List<string> { "Way" } };

        _mockScreeningQueryManager
            .Setup(m => m.GetResultAsync(query.Number))
            .ReturnsAsync(expectedResult);

        var result = await _handler.Handle(query, CancellationToken.None);

        result.Should().BeEquivalentTo(expectedResult);
        _mockScreeningQueryManager.Verify(m => m.GetResultAsync(query.Number), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldReturnKanzWay_WhenNumberIsDivisibleBy3And5()
    {
        var query = new GetScreeningResultQuery { Number = 15 };
        var expectedResult = new ScreeningResultDto { Results = new List<string> { "KanzWay" } };

        _mockScreeningQueryManager
            .Setup(m => m.GetResultAsync(query.Number))
            .ReturnsAsync(expectedResult);

        var result = await _handler.Handle(query, CancellationToken.None);

        result.Should().BeEquivalentTo(expectedResult);
        _mockScreeningQueryManager.Verify(m => m.GetResultAsync(query.Number), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldReturnNumber_WhenNumberIsNotDivisibleBy3Or5()
    {
        var query = new GetScreeningResultQuery { Number = 7 };
        var expectedResult = new ScreeningResultDto { Results = new List<string> { "7" } };

        _mockScreeningQueryManager
            .Setup(m => m.GetResultAsync(query.Number))
            .ReturnsAsync(expectedResult);

        var result = await _handler.Handle(query, CancellationToken.None);

        result.Should().BeEquivalentTo(expectedResult);
        _mockScreeningQueryManager.Verify(m => m.GetResultAsync(query.Number), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowException_WhenQueryManagerThrows()
    {
        var query = new GetScreeningResultQuery { Number = 0 };

        _mockScreeningQueryManager
            .Setup(m => m.GetResultAsync(query.Number))
            .ThrowsAsync(new System.Exception("Some error occurred"));

        var act = () => _handler.Handle(query, CancellationToken.None);

        await act.Should().ThrowAsync<System.Exception>()
                  .WithMessage("Some error occurred");
    }
}
