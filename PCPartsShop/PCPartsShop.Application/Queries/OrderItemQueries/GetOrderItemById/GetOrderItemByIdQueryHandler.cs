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

namespace PCPartsShop.Application.Queries.OrderItemQueries.GetOrderItemById
{
    public class GetOrderItemByIdQueryHandler : IRequestHandler<GetOrderItemByIdQuery, OrderItem>
    {
        private readonly PCPartsShopContext _context;
        public GetOrderItemByIdQueryHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<OrderItem> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _context.OrderItems.FirstOrDefaultAsync(i => i.OrderItemId == request.OrderItemId);
            if(item is null)
            {
                return null;
            }
            return item;
        }
    }
}
