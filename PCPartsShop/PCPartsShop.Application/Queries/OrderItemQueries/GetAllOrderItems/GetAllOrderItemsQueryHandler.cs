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

namespace PCPartsShop.Application.Queries.OrderItemQueries.GetAllOrderItems
{
    public class GetAllOrderItemsQueryHandler : IRequestHandler<GetAllOrderItemsQuery, ICollection<OrderItem>>
    {
        private readonly PCPartsShopContext _context;
        public GetAllOrderItemsQueryHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<ICollection<OrderItem>> Handle(GetAllOrderItemsQuery request, CancellationToken cancellationToken)
        {
            return await _context.OrderItems.ToListAsync();
        }
    }
}
