using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PCPartsShop.Application.Commands.MOBOCommands.CreateMOBO;
using PCPartsShop.Application.Commands.MOBOCommands.RemoveMOBO;
using PCPartsShop.Application.Commands.MOBOCommands.UpdateMOBO;
using PCPartsShop.Application.Queries.MOBOQueries.GetAllMOBOs;
using PCPartsShop.Application.Queries.MOBOQueries.GetMOBOById;
using PCPartsShop.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPartsShop.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MOBOController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public MOBOController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateMOBO([FromBody] CreateMOBODto mobo)
        {
            var command = _mapper.Map<CreateMOBOCommand>(mobo);

            var createdMobo = await _mediator.Send(command);
            var dto = _mapper.Map<GetMOBODto>(createdMobo);

            return CreatedAtAction(nameof(GetMOBOById), new { moboId = createdMobo.ComponentId }, dto);
        }

        [HttpGet]
        [Route("{moboId}")]
        public async Task<IActionResult> GetMOBOById(Guid moboId)
        {
            var query = new GetMOBOByIdQuery { MOBOId = moboId };
            var res = await _mediator.Send(query);
            return Ok(_mapper.Map<GetMOBODto>(res));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMOBOs()
        {
            List<GetMOBODto> mobos = new List<GetMOBODto>();
            var query = new GetAllMOBOsQuery();
            var res = await _mediator.Send(query);
            foreach (var m in res)
            {
                mobos.Add(_mapper.Map<GetMOBODto>(m));
            }
            return Ok(mobos);
        }

        [HttpDelete]
        [Route("{moboId}")]
        public async Task<IActionResult> RemoveMOBO(Guid moboId)
        {
            var command = new RemoveMOBOCommand { MOBOId = moboId };
            var res = await _mediator.Send(command);
            if (!res)
            {
                return NotFound($"{moboId} entry not found.");
            }
            return NoContent();
        }

        [HttpPut]
        [Route("{moboId}")]
        public async Task<IActionResult> UpdateMOBO(Guid moboId, [FromBody] CreateMOBODto moboToUpdate)
        {
            var command = new UpdateMOBOCommand
            {
                MOBOId = moboId,
                Make = moboToUpdate.Make,
                Model = moboToUpdate.Model,
                Price = moboToUpdate.Price,
                Image = moboToUpdate.Image,
                Socket = moboToUpdate.Socket,
                Chipset = moboToUpdate.Chipset,
                Format = moboToUpdate.Format,
                MemoryType = moboToUpdate.MemoryType,
                MemoryFreqInf = moboToUpdate.LowestFrequencySupported,
                MemoryFreqSup = moboToUpdate.HighestFrequencySupported
            };
            var res = await _mediator.Send(command);
            return Ok(_mapper.Map<GetMOBODto>(res));
        }
    }
}
