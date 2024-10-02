using KanzWayScreening.Application.Screening.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KanzWayScreening.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ScreeningController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ScreeningController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{number}")]
        public async Task<IActionResult> GetScreeningResultAsync(int number)
        {
            var query = new GetScreeningResultQuery { Number = number };
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }
    }
}
