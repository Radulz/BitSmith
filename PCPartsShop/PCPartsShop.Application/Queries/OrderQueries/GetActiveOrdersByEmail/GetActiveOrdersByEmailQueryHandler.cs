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

namespace PCPartsShop.Application.Queries.OrderQueries.GetActiveOrdersByEmail
{
    public class GetActiveOrdersByEmailQueryHandler : IRequestHandler<GetActiveOrdersByEmailQuery, ICollection<Order>>
    {
        private readonly PCPartsShopContext _context;
        public GetActiveOrdersByEmailQueryHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Order>> Handle(GetActiveOrdersByEmailQuery request, CancellationToken cancellationToken)
        {
            List<Order> activeOrders = new List<Order>();

            foreach (var item in _context.Orders.Include(o => o.Items))
            {
                if(item.UserEmail == request.UserEmail && !item.IsShipped)
                {
                    activeOrders.Add(item);
                }
            }

            return await Task.FromResult(activeOrders);
        }
    }
}
