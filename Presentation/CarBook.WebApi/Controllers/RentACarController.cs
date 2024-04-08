using CarBook.Application.Features.MediatR.Queries.RentACarQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarController : ControllerBase
    {

        private readonly IMediator _mediator;

        public RentACarController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetRentACarListByLocationId([FromQuery] GetRentACarQuery query)
        {

            var values = await _mediator.Send(query);
            return Ok(values);
        }
    }
}
