using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PCPartsShop.Application.Commands.RAMCommands.CreateRAM;
using PCPartsShop.Application.Commands.RAMCommands.RemoveRAM;
using PCPartsShop.Application.Commands.RAMCommands.UpdateRAM;
using PCPartsShop.Application.Queries.RAMQueries.GetAllRAMs;
using PCPartsShop.Application.Queries.RAMQueries.GetRAMById;
using PCPartsShop.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPartsShop.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RAMController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public RAMController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRAM([FromBody] CreateRAMDto ram)
        {
            var command = _mapper.Map<CreateRAMCommand>(ram);

            var createdRam = await _mediator.Send(command);
            var dto = _mapper.Map<GetRAMDto>(createdRam);

            return CreatedAtAction(nameof(GetRAMById), new { ramId = createdRam.ComponentId }, dto);
        }

        [HttpGet]
        [Route("{ramId}")]
        public async Task<IActionResult> GetRAMById(Guid ramId)
        {
            var query = new GetRAMByIdQuery { RAMId = ramId };
            var res = await _mediator.Send(query);
            return Ok(_mapper.Map<GetRAMDto>(res));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRAMs()
        {
            List<GetRAMDto> rams = new List<GetRAMDto>();
            var query = new GetAllRAMsQuery();
            var res = await _mediator.Send(query);
            foreach (var r in res)
            {
                rams.Add(_mapper.Map<GetRAMDto>(r));
            }
            return Ok(rams);
        }

        [HttpDelete]
        [Route("{ramId}")]
        public async Task<IActionResult> RemoveRAM(Guid ramId)
        {
            var command = new RemoveRAMCommand { RAMId = ramId };
            var res = await _mediator.Send(command);
            if (!res)
            {
                return NotFound($"{ramId} entry not found.");
            }
            return NoContent();
        }

        [HttpPut]
        [Route("{ramId}")]
        public async Task<IActionResult> UpdateGPU(Guid ramId, [FromBody] CreateRAMDto ramToUpdate)
        {
            var command = new UpdateRAMCommand
            {
                RAMId = ramId,
                Make = ramToUpdate.Make,
                Model = ramToUpdate.Model,
                Price = ramToUpdate.Price,
                Image = ramToUpdate.Image,
                Freq = ramToUpdate.Frequency,
                Capacity = ramToUpdate.Capacity,
                Type = ramToUpdate.Type,
                Voltage = ramToUpdate.Voltage,
            };
            var res = await _mediator.Send(command);
            return Ok(_mapper.Map<GetRAMDto>(res));
        }
    }
}
