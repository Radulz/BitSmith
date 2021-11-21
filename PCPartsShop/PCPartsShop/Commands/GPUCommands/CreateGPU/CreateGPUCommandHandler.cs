using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.GPUCommands.CreateGPU
{
    public class CreateGPUCommandHandler : IRequestHandler<CreateGPUCommand, Guid>
    {
        private readonly IComponentRepository<GPU> _GPUs;

        public CreateGPUCommandHandler(IComponentRepository<GPU> repository)
        {
            _GPUs = repository;
        }
        public Task<Guid> Handle(CreateGPUCommand request, CancellationToken cancellationToken)
        {
            var gpu = new GPU
            {
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
            _GPUs.Add(gpu);
            return Task.FromResult(gpu.ComponentId);
        }
    }
}
