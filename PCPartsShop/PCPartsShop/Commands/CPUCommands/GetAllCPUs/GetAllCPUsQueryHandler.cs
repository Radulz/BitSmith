using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.CPUCommands.GetAllCPUs
{
    public class GetAllCPUsQueryHandler : IRequestHandler<GetAllCPUsQuery, IEnumerable<CPU>>
    {
        private readonly IComponentRepository<CPU> _CPUs;

        public GetAllCPUsQueryHandler(IComponentRepository<CPU> repository)
        {
            _CPUs = repository;
        }
        public Task<IEnumerable<CPU>> Handle(GetAllCPUsQuery request, CancellationToken cancellationToken)
        {
            var result = _CPUs.GetAll();
            return Task.FromResult(result);
        }
    }
}
