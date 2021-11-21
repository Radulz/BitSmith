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
    public class GetCPUByIdCommandHandler : IRequestHandler<GetCPUByIdCommand, CPU>
    {
        private readonly IComponentRepository<CPU> _CPUs;
        public GetCPUByIdCommandHandler(IComponentRepository<CPU> repository)
        {
            _CPUs = repository;
        }
        public Task<CPU> Handle(GetCPUByIdCommand request, CancellationToken cancellationToken)
        {
            var cpu = _CPUs.GetItem(request.CPUId);
            return Task.FromResult(cpu);
        }
    }
}
