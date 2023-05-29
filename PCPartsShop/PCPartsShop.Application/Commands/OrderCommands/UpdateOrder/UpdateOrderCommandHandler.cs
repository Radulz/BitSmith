using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == request.OrderId);

            if (order == null)
            {
                return null;
            }

            order.OrderId = request.OrderId;
            order.UserEmail = request.UserEmail;
            order.UserFirstName = request.UserFirstName;
            order.UserLastName = request.UserLastName;
            order.UserCounty = request.UserCounty;
            order.UserCity = request.UserCity;
            order.UserAddress = request.UserAddress;
            order.IsShipped = request.IsShipped;
            order.TotalPrice = request.TotalPrice;
            order.Items = request.Items;
            
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
