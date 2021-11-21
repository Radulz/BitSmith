using MediatR;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.PSUCommands.GetAllPSUs
{
    public class GetAllPSUsCommand : IRequest<IEnumerable<PSU>>
    {
    }
}
