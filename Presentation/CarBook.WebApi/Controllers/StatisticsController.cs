using CarBook.Application.Features.MediatR.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarsCount()
        {

            var value = await _mediator.Send(new GetCarCountQuery());
            return Ok(value);

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetMostCountBrand()
        {

            var value = await _mediator.Send(new GetMostCountBrandQuery());
            return Ok(value);

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBrandAndModelDailyPriceIsMin()
        {

            var value = await _mediator.Send(new GetBrandAndModelDailyPriceIsMinQuery());
            return Ok(value);

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBrandAndModelDailyPriceIsMax()
        {

            var value = await _mediator.Send(new GetBrandAndModelDailyPriceIsMaxQuery());
            return Ok(value);

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAuthorCount()
        {

            var value = await _mediator.Send(new GetAuthorCountQuery());
            return Ok(value);

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBlogsCount()
        {

            var value = await _mediator.Send(new GetBlogsCountQuery());
            return Ok(value);

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBrandsCount()
        {

            var value = await _mediator.Send(new GetBrandsCountQuery());
            return Ok(value);

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarCountByElectric()
        {

            var value = await _mediator.Send(new GetCarCountByElectricQuery());
            return Ok(value);

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarCountByGasolineOrDiesel()
        {

            var value = await _mediator.Send(new GetCarCountByGasolineOrDieselQuery());
            return Ok(value);

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarCountByTransmissionIsAuto()
        {

            var value = await _mediator.Send(new GetCarCountByTransmissionIsAutoQuery());
            return Ok(value);

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarCountByKmLessThan1000()
        {

            var value = await _mediator.Send(new GetCarCountByKmLessThan1000Query());
            return Ok(value);

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetDailyAveragePrice()
        {

            var value = await _mediator.Send(new GetDailyAveragePriceQuery());
            return Ok(value);

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetMonthlyAveragePrice()
        {

            var value = await _mediator.Send(new GetMonthlyAveragePriceQuery());
            return Ok(value);

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetWeeklyAveragePrice()
        {

            var value = await _mediator.Send(new GetWeeklyAveragePriceQuery());
            return Ok(value);

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetLocationCount()
        {

            var value = await _mediator.Send(new GetLocationCountQuery());
            return Ok(value);

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetMostCommentBlog()
        {

            var value = await _mediator.Send(new GetMostCommentBlogQuery());
            return Ok(value);

        }
    }
}
