using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.RAMCommands.RemoveRAM
{
    public class RemoveRAMCommandHandler : IRequestHandler<RemoveRAMCommand, bool>
    {
        private readonly IComponentRepository<RAM> _RAMs;

        public RemoveRAMCommandHandler(IComponentRepository<RAM> repository)
        {
            _RAMs = repository;
        }
        public Task<bool> Handle(RemoveRAMCommand request, CancellationToken cancellationToken)
        {
            bool res = _RAMs.Delete(request.RAMId);
            return Task.FromResult(res);
        }
    }
}
