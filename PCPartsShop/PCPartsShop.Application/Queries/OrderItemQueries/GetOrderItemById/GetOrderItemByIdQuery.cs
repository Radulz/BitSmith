using MediatR;
using PCPartsShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Queries.OrderItemQueries.GetOrderItemById
{
    public class GetOrderItemByIdQuery : IRequest<OrderItem>
    {
        public int OrderItemId { get; set; }
    }
}
