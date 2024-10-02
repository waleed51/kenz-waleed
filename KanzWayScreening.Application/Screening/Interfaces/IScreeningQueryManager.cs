using KanzWayScreening.Application.Screening.Queries.Dtos;

namespace KanzWayScreening.Application.Screening.Interfaces
{
    public interface IScreeningQueryManager
    {
        Task<ScreeningResultDto> GetResultAsync(int number);
    }
}
