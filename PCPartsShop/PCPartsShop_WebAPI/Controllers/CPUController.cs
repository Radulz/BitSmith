using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PCPartsShop.Application.Commands.CPUCommands.CreateCPU;
using PCPartsShop.Application.Commands.CPUCommands.RemoveCPU;
using PCPartsShop.Application.Commands.CPUCommands.UpdateCPU;
using PCPartsShop.Dtos;
using PCPartsShop.Application.Queries.CPUQueries.GetAllCPUs;
using PCPartsShop.Application.Queries.CPUQueries.GetCPUById;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPartsShop.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CPUController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CPUController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCPU([FromBody] CreateCPUDto cpu)
        {
            var command = _mapper.Map<CreateCPUCommand>(cpu);

            var createdCpu = await _mediator.Send(command);
            var dto = _mapper.Map<GetCPUDto>(createdCpu);

            return CreatedAtAction(nameof(GetCPUById), new { cpuId = createdCpu.ComponentId }, dto);
        }

        [HttpGet]
        [Route("{cpuId}")]
        public async Task<IActionResult> GetCPUById(Guid cpuId)
        {
            var query = new GetCPUByIdQuery { CPUId = cpuId };
            var res = await _mediator.Send(query);
            return Ok(_mapper.Map<GetCPUDto>(res));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCPUs()
        {
            List<GetCPUDto> cpus = new List<GetCPUDto>();
            var query = new GetAllCPUsQuery();
            var res = await _mediator.Send(query);
            foreach (var c in res)
            {
                cpus.Add(_mapper.Map<GetCPUDto>(c));
            }
            return Ok(cpus);
        }

        [HttpDelete]
        [Route("{cpuId}")]
        public async Task<IActionResult> RemoveCPU(Guid cpuId)
        {
            var command = new RemoveCPUCommand { CPUId = cpuId };
            var res = await _mediator.Send(command);
            if (!res)
            {
                return NotFound($"{cpuId} entry not found.");
            }
            return NoContent();
        }

        [HttpPut]
        [Route("{cpuId}")]
        public async Task<IActionResult> UpdateCPU(Guid cpuId, [FromBody] CreateCPUDto cpuToUpdate)
        {
            var command = new UpdateCPUCommand
            {
                CPUId = cpuId,
                Make = cpuToUpdate.Make,
                Model = cpuToUpdate.Model,
                Price = cpuToUpdate.Price,
                Image = cpuToUpdate.Image,
                Freq = cpuToUpdate.Frequency,
                MFreq = cpuToUpdate.MemoryFrequency,
                Cores = cpuToUpdate.NumberOfCores,
                Socket = cpuToUpdate.Socket,
                TDP = cpuToUpdate.ThermalDesignPower,
                Tech = cpuToUpdate.Technology,
            };
            var res = await _mediator.Send(command);
            return Ok(_mapper.Map<GetCPUDto>(res));
        }
    }
}
