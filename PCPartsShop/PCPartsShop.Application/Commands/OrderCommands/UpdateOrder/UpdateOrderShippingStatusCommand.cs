using MediatR;
using PCPartsShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.OrderCommands.UpdateOrder
{
    public class UpdateOrderShippingStatusCommand : IRequest<Order>
    {
        public int OrderId { get; set; }
    }
}
