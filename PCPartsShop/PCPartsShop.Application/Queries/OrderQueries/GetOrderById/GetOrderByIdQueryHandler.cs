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

namespace PCPartsShop.Application.Queries.OrderQueries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly PCPartsShopContext _context;
        public GetOrderByIdQueryHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.Include(p => p.OrderItems).FirstOrDefaultAsync(o => o.OrderId == request.OrderId);
            if(order is null)
            {
                return null;
            }
            return order;
        }
    }
}
