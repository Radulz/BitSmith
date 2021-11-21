using MediatR;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.MOBOCommands.GetMOBO
{
    public class GetMOBOByIdCommand : IRequest<MOBO>
    {
        public Guid MOBOId { get; set; }
    }
}
