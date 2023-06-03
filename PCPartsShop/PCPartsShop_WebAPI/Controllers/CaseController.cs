using MediatR;
using Microsoft.AspNetCore.Mvc;
using PCPartsShop.Application.Commands.CaseCommands.CreateCase;
using PCPartsShop.Application.Commands.CaseCommands.RemoveCase;
using PCPartsShop.Application.Commands.CaseCommands.UpdateCase;
using PCPartsShop.Application.Queries.CaseQueries.GetAllCases;
using PCPartsShop.Application.Queries.CaseQueries.GetCaseById;
using PCPartsShop.Dtos;
using System;
using System.Threading.Tasks;

namespace PCPartsShop.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCase([FromBody] CreateCaseCommand command)
        {
            var createdCase = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateCase), new { caseId = createdCase.ComponentId }, createdCase);
        }

        [HttpDelete]
        [Route("{caseId}")]
        public async Task<IActionResult> DeleteCase(Guid caseId)
        {
            var command = new RemoveCaseCommand
            {
                CaseId = caseId
            };
            var caseToRemove = await _mediator.Send(command);
            if (caseToRemove)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPut]
        [Route("{caseId}")]
        public async Task<IActionResult> UpdateCase(Guid caseId, [FromBody] CreateCaseCommand command)
        {
            var cmd = new UpdateCaseCommand
            {
                CaseId = caseId,
                Make = command.Make,
                Model = command.Model,
                Price = command.Price,
                Image = command.Image,
                CaseType = command.CaseType,
                PSUPosition = command.PSUPosition,
                GPUMaximumLength = command.GPUMaximumLength,
                RadiatorSupport = command.RadiatorSupport,
                RadiatorSupportLength = command.RadiatorSupportLength,
                CoolerMaximumHeight = command.CoolerMaximumHeight,
            };

            var updatedCase = await _mediator.Send(cmd);

            if (updatedCase != null)
            {
                return Ok(updatedCase);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCases()
        {
            var query = new GetAllCasesQuery();
            var cases = await _mediator.Send(query);

            return Ok(cases);
        }

        [HttpGet]
        [Route("{caseId}")]
        public async Task<IActionResult> GetCaseById(Guid caseId)
        {
            var query = new GetCaseByIdQuery
            {
                CaseId = caseId
            };
            var pcCase = await _mediator.Send(query);

            if(pcCase != null)
            {
                return Ok(pcCase);
            }

            return NotFound();
        }
    }
}
