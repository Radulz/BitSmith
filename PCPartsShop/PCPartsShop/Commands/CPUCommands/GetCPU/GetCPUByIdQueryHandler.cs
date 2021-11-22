using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.CPUCommands.GetCPU
{
    public class GetCPUByIdQueryHandler : IRequestHandler<GetCPUByIdQuery, CPU>
    {
        private readonly IComponentRepository<CPU> _CPUs;
        public GetCPUByIdQueryHandler(IComponentRepository<CPU> repository)
        {
            _CPUs = repository;
        }
        public Task<CPU> Handle(GetCPUByIdQuery request, CancellationToken cancellationToken)
        {
            var cpu = _CPUs.GetItem(request.CPUId);
            return Task.FromResult(cpu);
        }
    }
}
