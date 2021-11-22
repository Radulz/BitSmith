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
    public class GetRAMByIdQueryHandler : IRequestHandler<GetRAMByIdQuery, RAM>
    {
        private readonly IComponentRepository<RAM> _RAMs;

        public GetRAMByIdQueryHandler(IComponentRepository<RAM> repository)
        {
            _RAMs = repository;
        }
        public Task<RAM> Handle(GetRAMByIdQuery request, CancellationToken cancellationToken)
        {
            var r = _RAMs.GetItem(request.RAMId);
            return Task.FromResult(r);
        }
    }
}
