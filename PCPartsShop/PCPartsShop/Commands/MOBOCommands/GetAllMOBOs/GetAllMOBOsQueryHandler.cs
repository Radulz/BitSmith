using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.MOBOCommands.GetAllMOBOs
{
    public class GetAllMOBOsQueryHandler : IRequestHandler<GetAllMOBOsQuery, IEnumerable<MOBO>>
    {
        private readonly IComponentRepository<MOBO> _MOBOs;

        public GetAllMOBOsQueryHandler(IComponentRepository<MOBO> repository)
        {
            _MOBOs = repository;
        }
        public Task<IEnumerable<MOBO>> Handle(GetAllMOBOsQuery request, CancellationToken cancellationToken)
        {
            var result = _MOBOs.GetAll();
            return Task.FromResult(result);
        }
    }
}
