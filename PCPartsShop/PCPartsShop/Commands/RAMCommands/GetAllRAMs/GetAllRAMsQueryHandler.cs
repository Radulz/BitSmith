using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.RAMCommands.GetAllRAMs
{
    public class GetAllRAMsQueryHandler : IRequestHandler<GetAllRAMsQuery, IEnumerable<RAM>>
    {
        private readonly IComponentRepository<RAM> _RAMs;

        public GetAllRAMsQueryHandler(IComponentRepository<RAM> repository)
        {
            _RAMs = repository;
        }
        public Task<IEnumerable<RAM>> Handle(GetAllRAMsQuery request, CancellationToken cancellationToken)
        {
            var result = _RAMs.GetAll();
            return Task.FromResult(result);
        }
    }
}
