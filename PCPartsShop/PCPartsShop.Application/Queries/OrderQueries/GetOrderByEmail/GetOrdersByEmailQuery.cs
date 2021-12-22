using MediatR;
using PCPartsShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Queries.OrderQueries.GetOrderByEmail
{
    public class GetOrdersByEmailQuery : IRequest<ICollection<Order>>
    {
        public string UserEmail { get; set; }
    }
}
