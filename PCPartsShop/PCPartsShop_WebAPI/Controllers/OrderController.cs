using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PCPartsShop.Application.Commands.OrderCommands.CreateOrder;
using PCPartsShop.Application.Commands.OrderCommands.RemoveOrder;
using PCPartsShop.Application.Commands.OrderCommands.UpdateOrder;
using PCPartsShop.Application.Queries.OrderQueries.GetActiveOrdersByEmail;
using PCPartsShop.Application.Queries.OrderQueries.GetAllOrders;
using PCPartsShop.Application.Queries.OrderQueries.GetOrderByEmail;
using PCPartsShop.Application.Queries.OrderQueries.GetOrderById;
using PCPartsShop.WebAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPartsShop.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand order)
        {
            var createdOrder = await _mediator.Send(order);
            var dto = _mapper.Map<GetOrderDto>(createdOrder);

            return CreatedAtAction(nameof(GetOrderById), new { OrderId = createdOrder.OrderId }, dto);
        }

        [HttpGet]
        [Route("{orderId}")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var query = new GetOrderByIdQuery { OrderId = orderId };
            var response = await _mediator.Send(query);
            if (response is null)
            {
                return NotFound($"The order with ID: {orderId} was not found!");
            }
            return Ok(_mapper.Map<GetOrderDto>(response));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            List<GetOrderDto> orders = new List<GetOrderDto>();
            var query = new GetAllOrdersQuery();
            var res = await _mediator.Send(query);
            foreach (var o in res)
            {
                orders.Add(_mapper.Map<GetOrderDto>(o));
            }
            return Ok(orders);
        }

        [HttpGet]
        [Route("orders/byEmail/{email}")]
        public async Task<IActionResult> GetOrdersByEmail(string email)
        {
            var query = new GetOrdersByEmailQuery { UserEmail = email };
            var response = await _mediator.Send(query);
            List<GetOrderDto> orders = new List<GetOrderDto>();
            foreach (var o in response)
            {
                orders.Add(_mapper.Map<GetOrderDto>(o));
            }
            return Ok(orders);
        }

        [HttpGet]
        [Route("orders/active/byEmail/{email}")]
        public async Task<IActionResult> GetActiveOrdersByEmail(string email)
        {
            var query = new GetActiveOrdersByEmailQuery { UserEmail = email };
            var response = await _mediator.Send(query);
            List<GetOrderDto> orders = new List<GetOrderDto>();
            foreach (var o in response)
            {
                orders.Add(_mapper.Map<GetOrderDto>(o));
            }
            return Ok(orders);
        }

        [HttpDelete]
        [Route("{orderId}")]
        public async Task<IActionResult> RemoveOrder(int orderId)
        {
            var command = new RemoveOrderCommand { OrderId = orderId };
            var response = await _mediator.Send(command);
            if(!response)
            {
                return NotFound($"The order with ID: {orderId} was not found!");
            }
            return NoContent();
        }

        [HttpPut]
        [Route("{orderId}")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommand order)
        {
            var response = await _mediator.Send(order);
            return Ok(_mapper.Map<GetOrderDto>(response));
        }

        [HttpPatch]
        [Route("{orderId}/orderItems")]
        public async Task<IActionResult> UpdateOrderItemList([FromBody] UpdateOrderItemListCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(_mapper.Map<GetOrderDto>(response));
        }
        [HttpPatch]
        [Route("{orderId}")]
        public async Task<IActionResult> UpdateShippingStatus([FromBody] UpdateOrderShippingStatusCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(_mapper.Map<GetOrderDto>(response));
        }
    }
}
