using MediatR;
using PCPartsShop.Infrastructure;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.GPUCommands.CreateGPU
{
    public class CreateGPUCommandHandler : IRequestHandler<CreateGPUCommand, GPU>
    {
        private readonly PCPartsShopContext _context;
        public CreateGPUCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<GPU> Handle(CreateGPUCommand request, CancellationToken cancellationToken)
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
            _context.GPUs.Add(gpu);
            await _context.SaveChangesAsync();
            return gpu;
        }
    }
}
