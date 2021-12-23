using MediatR;
using Microsoft.AspNetCore.Mvc;
using PCPartsShop.Application.Commands.UserCommands.CreateUser;
using PCPartsShop.Application.Commands.UserCommands.RemoveUser;
using PCPartsShop.Application.Commands.UserCommands.UpdateUser;
using PCPartsShop.Application.Queries.UserQueries.GetAllUsers;
using PCPartsShop.Application.Queries.UserQueries.GetUserByEmail;
using PCPartsShop.Application.Queries.UserQueries.GetUserById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPartsShop.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var response = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetUserById), new { UserId = response.UserId }, response);
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var query = new GetUserByIdQuery { UserId = userId };
            var response = await _mediator.Send(query);
            if(response == null)
            {
                return NotFound($"User with ID: {userId} was not found.");
            }
            return Ok(response);
        }
        [HttpGet]
        [Route("users/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var query = new GetUserByEmailQuery { Email = email };
            var response = await _mediator.Send(query);
            if (response == null)
            {
                return NotFound($"User with email: {email} was not found.");
            }
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetAllUsersQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> RemoveUser(Guid userId)
        {
            var command = new RemoveUserCommand { UserId = userId };
            var response = await _mediator.Send(command);
            if(!response)
            {
                return NotFound($"User with ID: {userId} was not found.");
            }
            return NoContent();
        }
        [HttpPut]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPatch]
        [Route("userId")]
        public async Task<IActionResult> UpdateUserAsAdmin(Guid userId)
        {
            var command = new UpdateUserAsAdminCommand { UserId = userId };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
