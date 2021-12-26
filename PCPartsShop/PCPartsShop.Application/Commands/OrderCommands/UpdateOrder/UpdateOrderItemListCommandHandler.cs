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
    public class UpdateOrderItemListCommandHandler : IRequestHandler<UpdateOrderItemListCommand, Order>
    {
        private readonly PCPartsShopContext _context;
        public UpdateOrderItemListCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<Order> Handle(UpdateOrderItemListCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.Include(p=>p.Items).FirstOrDefaultAsync(o => o.OrderId == request.OrderId);
            if(order is null)
            {
                return null;
            }
            var orderItem = new OrderItem
            {
                ComponentId = request.ComponentId,
                ComponentMake = request.ComponentMake,
                ComponentModel = request.ComponentModel,
                ComponentImage = request.ComponentImage,
                ComponentPrice = request.ComponentPrice,
                ComponentType = request.ComponentType,
            };
            order.Items.Add(orderItem);
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
