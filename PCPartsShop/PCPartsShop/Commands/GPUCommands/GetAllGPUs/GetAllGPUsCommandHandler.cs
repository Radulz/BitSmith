using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.GPUCommands.GetAllGPUs
{
    public class GetAllGPUsCommandHandler : IRequestHandler<GetAllGPUsCommand, IEnumerable<GPU>>
    {
        private readonly IComponentRepository<GPU> _GPUs;

        public GetAllGPUsCommandHandler(IComponentRepository<GPU> repository)
        {
            _GPUs = repository;
        }
        public Task<IEnumerable<GPU>> Handle(GetAllGPUsCommand request, CancellationToken cancellationToken)
        {
            var result = _GPUs.GetAll();
            return Task.FromResult(result);
        }
    }
}
