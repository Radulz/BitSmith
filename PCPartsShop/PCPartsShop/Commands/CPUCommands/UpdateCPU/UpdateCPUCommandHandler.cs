using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.CPUCommands.UpdateCPU
{
    public class UpdateCPUCommandHandler : IRequestHandler<UpdateCPUCommand, bool>
    {
        private readonly IComponentRepository<CPU> _CPUs;
        public UpdateCPUCommandHandler(IComponentRepository<CPU> repository)
        {
            _CPUs = repository;
        }
        public Task<bool> Handle(UpdateCPUCommand request, CancellationToken cancellationToken)
        {
            var cpu = new CPU
            {
                ComponentId = request.CPUId,
                Make = request.Make,
                Model = request.Model,
                Price = request.Price,
                Image = request.Image,
                Freq = request.Freq,
                MFreq = request.MFreq,
                Cores = request.Cores,
                Socket = request.Socket,
                TDP = request.TDP,
                Tech = request.Tech,
            };
            bool res = _CPUs.Update(cpu);
            return Task.FromResult(res);
        }
    }
}
