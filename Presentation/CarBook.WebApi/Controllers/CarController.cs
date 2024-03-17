using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CarBook.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CarController:ControllerBase
    {
        private readonly CreateCarCommandHandler _createCommandHandler;
        private readonly UpdateCarCommandHandler _updateCommandHandler;
        private readonly RemoveCarCommandHandler _removeCommandHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        public CarController(CreateCarCommandHandler createCommandHandler, UpdateCarCommandHandler updateCommandHandler, RemoveCarCommandHandler removeCommandHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler)
        {
            _createCommandHandler = createCommandHandler;
            _updateCommandHandler = updateCommandHandler;
            _removeCommandHandler = removeCommandHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetCars()
        {

            var values = await _getCarQueryHandler.Handle();
            return Ok(values);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarsWithBrand()
        {

            var values = await _getCarWithBrandQueryHandler.Handle();
            return Ok(values);

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var car = await _getCarByIdQueryHandler.Handle(new Application.Features.CQRS.Queries.CarQueries.GetCarByIdQuery(id));
            return Ok(car);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCarCommand command)
        {


            await _createCommandHandler.Handle(command);
            return Ok("Araç Bilgisi Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCarCommand command)
        {

            await _updateCommandHandler.Handle(command);
            return Ok("Araç Bilgisi Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {


            await _removeCommandHandler.Handle( new RemoveCarCommand(id));
            return Ok("Araç Bilgisi Silindi");
        }
    }
}
