using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.CaseCommands.RemoveCase
{
    public class RemoveCaseCommand : IRequest<bool>
    {
        public Guid CaseId { get; set; }
    }
}
