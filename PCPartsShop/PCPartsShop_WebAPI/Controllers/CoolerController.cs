using MediatR;
using Microsoft.AspNetCore.Mvc;
using PCPartsShop.Application.Commands.CoolerCommands.CreateCooler;
using PCPartsShop.Application.Commands.CoolerCommands.RemoveCooler;
using PCPartsShop.Application.Commands.CoolerCommands.UpdateCooler;
using PCPartsShop.Application.Queries.CoolerQueries.GetAllCoolers;
using PCPartsShop.Application.Queries.CoolerQueries.GetCoolerById;
using System.Threading.Tasks;
using System;

namespace PCPartsShop.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CoolerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoolerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCooler([FromBody] CreateCoolerCommand command)
        {
            var createdcooler = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateCooler), new { cpuId = createdcooler.ComponentId }, createdcooler);
        }

        [HttpDelete]
        [Route("{coolerId}")]
        public async Task<IActionResult> DeleteCooler(Guid coolerId)
        {
            var command = new RemoveCoolerCommand
            {
                CoolerId = coolerId
            };
            var coolerToRemove = await _mediator.Send(command);
            if (coolerToRemove)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPut]
        [Route("{coolerId}")]
        public async Task<IActionResult> UpdateCooler(Guid coolerId, [FromBody] UpdateCoolerCommand command)
        {
            var cmd = new UpdateCoolerCommand
            {
                CoolerId = coolerId,
                Make = command.Make,
                Model = command.Model,
                Price = command.Price,
                Image = command.Image,
                CoolingType= command.CoolingType,
                Height=command.Height,
                NumberOfHeatPipes=command.NumberOfHeatPipes,
                RadiatorLength=command.RadiatorLength,
            };

            var updatedCooler = await _mediator.Send(cmd);

            if (updatedCooler != null)
            {
                return Ok(updatedCooler);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoolers()
        {
            var query = new GetAllCoolersQuery();
            var coolers = await _mediator.Send(query);

            return Ok(coolers);
        }

        [HttpGet]
        [Route("{coolerId}")]
        public async Task<IActionResult> GetCoolerById(Guid coolerId)
        {
            var query = new GetCoolerByIdQuery
            {
                CoolerId = coolerId
            };
            var cooler = await _mediator.Send(query);

            if (cooler != null)
            {
                return Ok(cooler);
            }

            return NotFound();
        }
    }
}
