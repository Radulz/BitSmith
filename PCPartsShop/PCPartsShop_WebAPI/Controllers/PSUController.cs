using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PCPartsShop.Application.Commands.PSUCommands.CreatePSU;
using PCPartsShop.Application.Commands.PSUCommands.RemovePSU;
using PCPartsShop.Application.Commands.PSUCommands.UpdatePSU;
using PCPartsShop.Application.Queries.PSUQueries.GetAllPSUs;
using PCPartsShop.Application.Queries.PSUQueries.GetPSUById;
using PCPartsShop.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPartsShop.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PSUController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PSUController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePSU([FromBody] CreatePSUDto psu)
        {
            var command = _mapper.Map<CreatePSUCommand>(psu);

            var createdPsu = await _mediator.Send(command);
            var dto = _mapper.Map<GetPSUDto>(createdPsu);

            return CreatedAtAction(nameof(GetPSUById), new { psuId = createdPsu.ComponentId }, dto);
        }

        [HttpGet]
        [Route("{psuId}")]
        public async Task<IActionResult> GetPSUById(Guid psuId)
        {
            var query = new GetPSUByIdQuery { PSUId = psuId };
            var res = await _mediator.Send(query);
            return Ok(_mapper.Map<GetPSUDto>(res));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPSUs()
        {
            List<GetPSUDto> psus = new List<GetPSUDto>();
            var query = new GetAllPSUsQuery();
            var res = await _mediator.Send(query);
            foreach (var p in res)
            {
                psus.Add(_mapper.Map<GetPSUDto>(p));
            }
            return Ok(psus);
        }

        [HttpDelete]
        [Route("{psuId}")]
        public async Task<IActionResult> RemovePSU(Guid psuId)
        {
            var command = new RemovePSUCommand { PSUId = psuId };
            var res = await _mediator.Send(command);
            if (!res)
            {
                return NotFound($"{psuId} entry not found.");
            }
            return NoContent();
        }

        [HttpPut]
        [Route("{psuId}")]
        public async Task<IActionResult> UpdatePSU(Guid psuId, [FromBody] CreatePSUDto psuToUpdate)
        {
            var command = new UpdatePSUCommand
            {
                PSUId = psuId,
                Make = psuToUpdate.Make,
                Model = psuToUpdate.Model,
                Price = psuToUpdate.Price,
                Image = psuToUpdate.Image,
                Power = psuToUpdate.Power,
                Type = psuToUpdate.Modularity
            };
            var res = await _mediator.Send(command);
            if (res is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetPSUDto>(res));
        }
    }
}
