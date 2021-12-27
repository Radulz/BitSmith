using MediatR;
using PCPartsShop.Domain.Models;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.OrderItemCommands.UpdateOrderItem
{
    public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand, OrderItem>
    {
        private readonly PCPartsShopContext _context;
        public UpdateOrderItemCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<OrderItem> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = new OrderItem
            {
                OrderItemId = request.OrderItemId,
                ComponentId = request.ComponentId,
                ComponentMake = request.ComponentMake,
                ComponentModel = request.ComponentModel,
                ComponentImage = request.ComponentImage,
                ComponentPrice = request.ComponentPrice,
                ComponentType = request.ComponentType,
                OrderItemQuantity = request.OrderItemQuantity,
                OrderId = request.OrderId,
            };
            _context.OrderItems.Update(orderItem);
            await _context.SaveChangesAsync();
            return orderItem;
        }
    }
}
