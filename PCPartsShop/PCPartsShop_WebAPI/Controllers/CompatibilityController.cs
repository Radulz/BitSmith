using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using PCPartsShop.WebAPI.Dtos;
using System.Threading.Tasks;
using System.Collections.Generic;
using PCPartsShop.Application.Commands.CompatibilityCommands;

namespace PCPartsShop.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompatibilityController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CompatibilityController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("parts")]
        public async Task<IActionResult> CompatibilityMessages([FromBody] CreateCompatibilityCommand partsList)
        {

            var response = await _mediator.Send(partsList);

            return await Task.FromResult(Ok(response));
        }
    }
}
