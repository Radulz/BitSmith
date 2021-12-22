using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.OrderCommands.RemoveOrder
{
    public class RemoveOrderCommand : IRequest<bool>
    {
        public int OrderId { get; set; }
    }
}
