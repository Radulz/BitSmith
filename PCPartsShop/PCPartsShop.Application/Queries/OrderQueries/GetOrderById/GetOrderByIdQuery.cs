using MediatR;
using PCPartsShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Queries.OrderQueries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public int OrderId { get; set; }
    }
}
