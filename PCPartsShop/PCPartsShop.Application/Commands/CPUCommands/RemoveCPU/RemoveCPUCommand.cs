using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.CPUCommands.RemoveCPU
{
    public class RemoveCPUCommand : IRequest<bool>
    {
        public Guid CPUId { get; set; }
    }
}
