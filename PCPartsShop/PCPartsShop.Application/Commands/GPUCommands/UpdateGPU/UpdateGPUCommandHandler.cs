using MediatR;
using PCPartsShop.Infrastructure;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.GPUCommands.UpdateGPU
{
    public class UpdateGPUCommandHandler : IRequestHandler<UpdateGPUCommand, GPU>
    {
        private readonly PCPartsShopContext _context;
        public UpdateGPUCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<GPU> Handle(UpdateGPUCommand request, CancellationToken cancellationToken)
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
            _context.GPUs.Update(gpu);
            await _context.SaveChangesAsync();
            return gpu;
        }
    }
}
