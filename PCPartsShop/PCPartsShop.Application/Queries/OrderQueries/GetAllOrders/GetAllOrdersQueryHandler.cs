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

namespace PCPartsShop.Application.Queries.OrderQueries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, ICollection<Order>>
    {
        private readonly PCPartsShopContext _context;
        public GetAllOrdersQueryHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders.Include(p => p.OrderItems).ToListAsync();
            return orders;
        }
    }
}
