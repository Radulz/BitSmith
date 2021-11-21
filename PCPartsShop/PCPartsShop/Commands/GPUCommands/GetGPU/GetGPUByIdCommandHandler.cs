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
    public class GetGPUByIdCommandHandler : IRequestHandler<GetGPUByIdCommand, GPU>
    {
        private readonly IComponentRepository<GPU> _GPUs;
        public GetGPUByIdCommandHandler(IComponentRepository<GPU> repository)
        {
            _GPUs = repository;
        }
        public Task<GPU> Handle(GetGPUByIdCommand request, CancellationToken cancellationToken)
        {
            var gpu = _GPUs.GetItem(request.GPUId);
            return Task.FromResult(gpu);
        }
    }
}
