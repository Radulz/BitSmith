using MediatR;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.CPUCommands.GetCPU
{
    public class GetCPUByIdQuery : IRequest<CPU>
    {
        public Guid CPUId { get; set; }
    }
}
