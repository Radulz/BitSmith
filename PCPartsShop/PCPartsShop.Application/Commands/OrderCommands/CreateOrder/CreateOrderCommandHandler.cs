using MediatR;
using PCPartsShop.Domain.Models;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.OrderCommands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly PCPartsShopContext _context;
        public CreateOrderCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                UserEmail = request.UserEmail,
                UserFirstName = request.UserFirstName,
                UserLastName = request.UserLastName,
                UserCounty = request.UserCounty,
                UserCity = request.UserCity,
                UserAddress = request.UserAddress,
                TotalPrice = request.TotalPrice,
                IsShipped = false,
                Items = new List<OrderItem>(),
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;

        }
    }
}
