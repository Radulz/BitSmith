using MediatR;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.GPUCommands.GetGPU
{
    public class GetGPUByIdCommand : IRequest<GPU>
    {
        public Guid GPUId { get; set; }
    }
}
