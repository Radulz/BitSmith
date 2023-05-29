using MediatR;
using Microsoft.AspNetCore.Mvc;
using PCPartsShop.Application.Commands.SSDCommands.CreateSSD;
using PCPartsShop.Application.Commands.SSDCommands.RemoveSSD;
using PCPartsShop.Application.Commands.SSDCommands.UpdateSSD;
using PCPartsShop.Application.Queries.SSDQueries.GetAllSSDs;
using PCPartsShop.Application.Queries.SSDQueries.GetSSDById;
using System.Threading.Tasks;
using System;

namespace PCPartsShop.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SSDController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SSDController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSSD([FromBody] CreateSSDCommand command)
        {
            var createdSSD = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateSSD), new { cpuId = createdSSD.ComponentId }, createdSSD);
        }

        [HttpDelete]
        [Route("{SSDId}")]
        public async Task<IActionResult> DeleteSSD([FromBody] RemoveSSDCommand command)
        {
            var SSDToRemove = await _mediator.Send(command);
            if (SSDToRemove)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("{SSDId}")]
        public async Task<IActionResult> UpdateSSD(Guid SSDId, [FromBody] UpdateSSDCommand command)
        {
            var cmd = new UpdateSSDCommand
            {
                SSDId = SSDId,
                Make = command.Make,
                Model = command.Model,
                Price = command.Price,
                Image = command.Image,
                Capacity= command.Capacity,
                Connector= command.Connector,
            };

            var updatedSSD = await _mediator.Send(cmd);

            if (updatedSSD != null)
            {
                return Ok(updatedSSD);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSSDs()
        {
            var query = new GetAllSSDsQuery();
            var SSDs = await _mediator.Send(query);

            return Ok(SSDs);
        }

        [HttpGet]
        [Route("{SSDId}")]
        public async Task<IActionResult> GetSSDById(Guid SSDId)
        {
            var query = new GetSSDByIdQuery
            {
                SSDId = SSDId
            };

            var SSD = await _mediator.Send(query);

            if (SSD != null)
            {
                return Ok(SSD);
            }

            return NotFound();
        }
    }
}
