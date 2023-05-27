using MediatR;
using Microsoft.AspNetCore.Mvc;
using PCPartsShop.Application.Commands.CompatibilityCommands;
using PCPartsShop.Application.Commands.EmailCommands;
using PCPartsShop.Application.Queries.OrderQueries.GetOrderById;
using System.Threading.Tasks;

namespace PCPartsShop.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("compose/{orderId}")]
        public async Task<IActionResult> SendEmailWithOrder(int orderId)
        {
            var orderById = new GetOrderByIdQuery { OrderId = orderId };
            var query = await _mediator.Send(orderById);

            var emailCmd = new CreateEmailWithOrderCommand
            {
                Order = query
            };

            var response = await _mediator.Send(emailCmd);

            if(response != null)
            {
                return await Task.FromResult(Ok(response));
            }

            return BadRequest(response);
        }
    }
}
