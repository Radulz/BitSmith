using MediatR;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.RAMCommands.GetAllRAMs
{
    public class GetAllRAMsQuery : IRequest<IEnumerable<RAM>>
    {
    }
}
