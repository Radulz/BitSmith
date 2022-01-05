using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PCPartsShop.Application.Commands.GPUCommands.CreateGPU;
using PCPartsShop.Application.Commands.GPUCommands.RemoveGPU;
using PCPartsShop.Application.Commands.GPUCommands.UpdateGPU;
using PCPartsShop.Application.Queries.GPUQueries.GetAllGPUs;
using PCPartsShop.Application.Queries.GPUQueries.GetGPUById;
using PCPartsShop.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPartsShop.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GPUController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public GPUController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateGPU([FromBody] CreateGPUDto gpu)
        {
            var command = _mapper.Map<CreateGPUCommand>(gpu);

            var createdGpu = await _mediator.Send(command);
            var dto = _mapper.Map<GetGPUDto>(createdGpu);

            return CreatedAtAction(nameof(GetGPUById), new { gpuId = createdGpu.ComponentId }, dto);
        }

        [HttpGet]
        [Route("{gpuId}")]
        public async Task<IActionResult> GetGPUById(Guid gpuId)
        {
            var query = new GetGPUByIdQuery { GPUId = gpuId };
            var res = await _mediator.Send(query);
            return Ok(_mapper.Map<GetGPUDto>(res));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGPUs()
        {
            List<GetGPUDto> gpus = new List<GetGPUDto>();
            var query = new GetAllGPUsQuery();
            var res = await _mediator.Send(query);
            foreach (var g in res)
            {
                gpus.Add(_mapper.Map<GetGPUDto>(g));
            }
            return Ok(gpus);
        }

        [HttpDelete]
        [Route("{gpuId}")]
        public async Task<IActionResult> RemoveGPU(Guid gpuId)
        {
            var command = new RemoveGPUCommand { GPUId = gpuId };
            var res = await _mediator.Send(command);
            if (!res)
            {
                return NotFound($"{gpuId} entry not found.");
            }
            return NoContent();
        }

        [HttpPut]
        [Route("{gpuId}")]
        public async Task<IActionResult> UpdateGPU(Guid gpuId, [FromBody] CreateGPUDto gpuToUpdate)
        {
            var command = new UpdateGPUCommand
            {
                GPUId = gpuId,
                Make = gpuToUpdate.Make,
                Model = gpuToUpdate.Model,
                Price = gpuToUpdate.Price,
                Image = gpuToUpdate.Image,
                Freq = gpuToUpdate.Frequency,
                Memory = gpuToUpdate.MemoryCapacity,
                MemoryType = gpuToUpdate.MemoryType,
                PowerC = gpuToUpdate.PowerConsumption,
                Tech = gpuToUpdate.Technology,
                Length = gpuToUpdate.Length,
            };
            var res = await _mediator.Send(command);
            if (res is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetGPUDto>(res));
        }
    }

}
