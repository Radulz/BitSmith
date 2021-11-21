using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.GPUCommands.RemoveGPU
{
    public class RemoveGPUCommandHandler : IRequestHandler<RemoveGPUCommand, bool>
    {
        private readonly IComponentRepository<GPU> _GPUs;
        public RemoveGPUCommandHandler(IComponentRepository<GPU> repository)
        {
            _GPUs = repository;
        }
        public Task<bool> Handle(RemoveGPUCommand request, CancellationToken cancellationToken)
        {
            bool res = _GPUs.Delete(request.GPUId);
            return Task.FromResult(res);
        }
    }
}
