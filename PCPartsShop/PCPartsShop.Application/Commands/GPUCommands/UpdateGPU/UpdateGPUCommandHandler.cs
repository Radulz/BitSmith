using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var gpu = await _context.GPUs.FirstOrDefaultAsync(x => x.ComponentId == request.GPUId);

            if (gpu == null)
            {
                return null;
            }


            gpu.ComponentId = request.GPUId;
            gpu.Make = request.Make;
            gpu.Model = request.Model;
            gpu.Price = request.Price;
            gpu.Image = request.Image;
            gpu.Freq = request.Freq;
            gpu.Memory = request.Memory;
            gpu.MemoryType = request.MemoryType;
            gpu.PowerC = request.PowerC;
            gpu.Tech = request.Tech;
            gpu.Length = request.Length;

            _context.GPUs.Update(gpu);
            await _context.SaveChangesAsync();
            return gpu;
        }
    }
}
