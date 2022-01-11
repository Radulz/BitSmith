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
            _context.CPUs.Update(cpu);
            await _context.SaveChangesAsync();
            return cpu;
        }
    }
}
