using KanzWayScreening.Application.Screening.Interfaces;
using KanzWayScreening.Application.Screening.Queries.Dtos;
using MediatR;

namespace KanzWayScreening.Application.Screening.Queries
{
    public class GetScreeningResultQuery : IRequest<ScreeningResultDto>
    {
        public int Number { get; set; }
    }
    public class GetScreeningResultQueryHandler : IRequestHandler<GetScreeningResultQuery, ScreeningResultDto>
    {
        private readonly IScreeningQueryManager _screeningManager;
        public GetScreeningResultQueryHandler(IScreeningQueryManager screeningManager)
        {
            _screeningManager = screeningManager;
        }
        public async Task<ScreeningResultDto> Handle(GetScreeningResultQuery request, CancellationToken cancellationToken)
        {
            return await _screeningManager.GetResultAsync(request.Number);
        }
    }
}
