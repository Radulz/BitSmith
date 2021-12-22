using MediatR;
using Microsoft.EntityFrameworkCore;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.OrderItemCommands.RemoveOrderItem
{
    public class RemoveOrderItemCommandHandler : IRequestHandler<RemoveOrderItemCommand, bool>
    {
        private readonly PCPartsShopContext _context;
        public RemoveOrderItemCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.OrderItems.FirstOrDefaultAsync(i => i.OrderItemId == request.OrderItemId);
            if(item is null)
            {
                return false;
            }
            _context.OrderItems.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
