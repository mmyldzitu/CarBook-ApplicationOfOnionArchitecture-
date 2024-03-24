using CarBook.Application.Features.MediatR.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingController : ControllerBase
    {


        private readonly IMediator _mediator;

        public CarPricingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{id}")]
        
        public async Task<IActionResult> GetCarPricingsWithCar(int id)
        {
            var values = await _mediator.Send( new GetCarPricingWithCarQuery(id) );
            return Ok(values);
        }
    }
}
