using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.CPUCommands.RemoveCPU
{
    public class RemoveCPUCommandHandler : IRequestHandler<RemoveCPUCommand, bool>
    {
        private readonly IComponentRepository<CPU> _CPUs;
        public RemoveCPUCommandHandler(IComponentRepository<CPU> repository)
        {
            _CPUs = repository;
        }
        public Task<bool> Handle(RemoveCPUCommand request, CancellationToken cancellationToken)
        {
            bool res = _CPUs.Delete(request.CPUId);
            return Task.FromResult(res);
        }
    }
}
