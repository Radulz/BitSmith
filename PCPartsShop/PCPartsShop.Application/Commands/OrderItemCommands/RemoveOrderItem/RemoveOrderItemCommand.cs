using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.OrderItemCommands.RemoveOrderItem
{
    public class RemoveOrderItemCommand : IRequest<bool>
    {
        public int OrderItemId { get; set; }
    }
}
