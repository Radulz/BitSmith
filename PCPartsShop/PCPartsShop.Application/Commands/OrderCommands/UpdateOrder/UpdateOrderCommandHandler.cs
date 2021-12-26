using MediatR;
using PCPartsShop.Domain.Models;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.OrderCommands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Order>
    {
        private readonly PCPartsShopContext _context;
        public UpdateOrderCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<Order> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                OrderId = request.OrderId,
                UserEmail = request.UserEmail,
                UserFirstName = request.UserFirstName,
                UserLastName = request.UserLastName,
                UserCounty = request.UserCounty,
                UserCity = request.UserCity,
                UserAddress = request.UserAddress,
                IsShipped = request.IsShipped,
                TotalPrice = request.TotalPrice,
                Items = request.Items
            };
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
