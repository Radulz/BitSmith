using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.PSUCommands.RemovePSU
{
    public class RemovePSUCommand : IRequest<bool>
    {
        public Guid PSUId { get; set; }
    }
}
