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

namespace PCPartsShop.Application.Commands.CPUCommands.UpdateCPU
{
    public class UpdateCPUCommandHandler : IRequestHandler<UpdateCPUCommand, CPU>
    {
        private readonly PCPartsShopContext _context;
        public UpdateCPUCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<CPU> Handle(UpdateCPUCommand request, CancellationToken cancellationToken)
        {
            var cpu = await _context.CPUs.FirstOrDefaultAsync(x => x.ComponentId == request.CPUId);
            if (cpu == null)
            {
                return null;
            }

            cpu.ComponentId = request.CPUId;
            cpu.Make = request.Make;
            cpu.Model = request.Model;
            cpu.Price = request.Price;
            cpu.Image = request.Image;
            cpu.Freq = request.Freq;
            cpu.MFreq = request.MFreq;
            cpu.Cores = request.Cores;
            cpu.Socket = request.Socket;
            cpu.TDP = request.TDP;
            cpu.Tech = request.Tech;

            _context.CPUs.Update(cpu);
            await _context.SaveChangesAsync();
            return cpu;
        }
    }
}
