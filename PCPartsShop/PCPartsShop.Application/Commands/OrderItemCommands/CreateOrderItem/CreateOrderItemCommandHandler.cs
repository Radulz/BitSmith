using MediatR;
using PCPartsShop.Domain.Models;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.OrderItemCommands.CreateOrderItem
{
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, OrderItem>
    {
        private readonly PCPartsShopContext _context;
        public CreateOrderItemCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<OrderItem> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var item = new OrderItem
            {
                ComponentId = request.ComponentId,
                ComponentImage = request.ComponentImage,
                ComponentMake = request.ComponentMake,
                ComponentModel = request.ComponentModel,
                ComponentPrice = request.ComponentPrice,
                ComponentType = request.ComponentType,
                OrderItemQuantity = request.OrderItemQuantity,
                OrderId = request.OrderId,
            };
            _context.OrderItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
