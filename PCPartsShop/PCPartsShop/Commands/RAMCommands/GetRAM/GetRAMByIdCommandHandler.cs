using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.RAMCommands.GetRAM
{
    public class GetRAMByIdCommandHandler : IRequestHandler<GetRAMByIdCommand, RAM>
    {
        private readonly IComponentRepository<RAM> _RAMs;

        public GetRAMByIdCommandHandler(IComponentRepository<RAM> repository)
        {
            _RAMs = repository;
        }
        public Task<RAM> Handle(GetRAMByIdCommand request, CancellationToken cancellationToken)
        {
            var r = _RAMs.GetItem(request.RAMId);
            return Task.FromResult(r);
        }
    }
}
