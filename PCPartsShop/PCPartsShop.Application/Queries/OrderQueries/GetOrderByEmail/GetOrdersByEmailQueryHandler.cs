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

namespace PCPartsShop.Application.Queries.OrderQueries.GetOrderByEmail
{
    public class GetOrdersByEmailQueryHandler : IRequestHandler<GetOrdersByEmailQuery, ICollection<Order>>
    {
        private readonly PCPartsShopContext _context;
        public GetOrdersByEmailQueryHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Order>> Handle(GetOrdersByEmailQuery request, CancellationToken cancellationToken)
        {
            List<Order> orders = new List<Order>();
            foreach (var item in _context.Orders.Include(o => o.Items))
            {
                if(item.UserEmail == request.UserEmail)
                {
                    orders.Add(item);
                }
            }
            return await Task.FromResult(orders);
        }
    }
}
