using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.GPUCommands.UpdateGPU
{
    public class UpdateGPUCommandHandler : IRequestHandler<UpdateGPUCommand, bool>
    {
        private readonly IComponentRepository<GPU> _GPUs;
        public UpdateGPUCommandHandler(IComponentRepository<GPU> repository)
        {
            _GPUs = repository;
        }
        public Task<bool> Handle(UpdateGPUCommand request, CancellationToken cancellationToken)
        {
            var gpu = new GPU
            {
                ComponentId = request.GPUId,
                Make = request.Make,
                Model = request.Model,
                Price = request.Price,
                Image = request.Image,
                Freq = request.Freq,
                Memory = request.Memory,
                MemoryType = request.MemoryType,
                PowerC = request.PowerC,
                Tech = request.Tech,
                Length = request.Length,
            };
            bool res = _GPUs.Update(gpu);
            return Task.FromResult(res);
        }
    }
}
