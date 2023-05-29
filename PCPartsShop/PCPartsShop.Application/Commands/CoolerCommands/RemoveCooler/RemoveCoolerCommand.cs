using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.CoolerCommands.RemoveCooler
{
    public class RemoveCoolerCommand : IRequest<bool>
    {
        public Guid CoolerId { get; set; }
    }
}
