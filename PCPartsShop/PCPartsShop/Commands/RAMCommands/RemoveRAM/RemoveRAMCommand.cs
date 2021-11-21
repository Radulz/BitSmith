using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.RAMCommands.RemoveRAM
{
    public class RemoveRAMCommand : IRequest<bool>
    {
        public Guid RAMId { get; set; }
    }
}
