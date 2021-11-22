using MediatR;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.PSUCommands.GetPSU
{
    public class GetPSUByIdQuery : IRequest<PSU>
    {
        public Guid PSUId { get; set; }
    }
}
