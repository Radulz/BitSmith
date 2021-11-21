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
    public class GetAllCPUsCommandHandler : IRequestHandler<GetAllCPUsCommand, IEnumerable<CPU>>
    {
        private readonly IComponentRepository<CPU> _CPUs;

        public GetAllCPUsCommandHandler(IComponentRepository<CPU> repository)
        {
            _CPUs = repository;
        }
        public Task<IEnumerable<CPU>> Handle(GetAllCPUsCommand request, CancellationToken cancellationToken)
        {
            var result = _CPUs.GetAll();
            return Task.FromResult(result);
        }
    }
}
