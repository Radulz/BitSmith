using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.GPUCommands.GetGPU
{
    public class GetGPUByIdQueryHandler : IRequestHandler<GetGPUByIdQuery, GPU>
    {
        private readonly IComponentRepository<GPU> _GPUs;
        public GetGPUByIdQueryHandler(IComponentRepository<GPU> repository)
        {
            _GPUs = repository;
        }
        public Task<GPU> Handle(GetGPUByIdQuery request, CancellationToken cancellationToken)
        {
            var gpu = _GPUs.GetItem(request.GPUId);
            return Task.FromResult(gpu);
        }
    }
}
