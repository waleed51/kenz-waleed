using KanzWayScreening.Application.Screening.Interfaces;
using KanzWayScreening.Application.Screening.Queries.Dtos;
using KanzWayScreening.Domain.Entities;

namespace KanzWayScreening.Application.Screening.Queries
{
    public class ScreeningQueryManager : IScreeningQueryManager
    {
        public Task<ScreeningResultDto> GetResultAsync(int number)
        {
            try
            {
                var result = new ScreeningResult();

                if (number % 3 == 0 && number % 5 == 0)
                {
                    result.AddResult("KanzWay");
                }
                else if (number % 3 == 0)
                {
                    result.AddResult("Kanz");
                }
                else if (number % 5 == 0)
                {
                    result.AddResult("Way");
                }
                else
                {
                    result.AddResult(number.ToString());
                }

                return Task.FromResult(new ScreeningResultDto
                {
                    Results = result.Results
                });
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while processing the request.", ex);
            }
        }

    }
}
