using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.SSDCommands.RemoveSSD
{
    public class RemoveSSDCommand : IRequest<bool>
    {
        public Guid SSDId { get; set; }
    }
}
