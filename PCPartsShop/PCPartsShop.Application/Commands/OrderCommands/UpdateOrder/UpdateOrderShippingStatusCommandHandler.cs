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
    public class UpdateOrderShippingStatusCommandHandler : IRequestHandler<UpdateOrderShippingStatusCommand, Order>
    {
        private readonly PCPartsShopContext _context;
        public UpdateOrderShippingStatusCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<Order> Handle(UpdateOrderShippingStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == request.OrderId);
            if(order is null)
            {
                return null;
            }
            order.IsShipped = true;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
