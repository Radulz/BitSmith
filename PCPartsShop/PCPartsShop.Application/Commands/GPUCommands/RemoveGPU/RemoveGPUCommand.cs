using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.GPUCommands.RemoveGPU
{
    public class RemoveGPUCommand : IRequest<bool>
    {
        public Guid GPUId { get; set; }
    }
}
