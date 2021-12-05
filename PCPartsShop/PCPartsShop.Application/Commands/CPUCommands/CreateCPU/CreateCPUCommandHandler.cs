using MediatR;
using PCPartsShop.Infrastructure;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.CPUCommands.CreateCPU
{
    public class CreateCPUCommandHandler : IRequestHandler<CreateCPUCommand, CPU>
    {
        private readonly PCPartsShopContext _context;
        public CreateCPUCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<CPU> Handle(CreateCPUCommand request, CancellationToken cancellationToken)
        {
            var cpu = new CPU
            {
                Make = request.Make,
                Model = request.Model,
                Price = request.Price,
                Image = request.Image,
                Freq = request.Freq,
                MFreq = request.MFreq,
                Socket = request.Socket,
                TDP = request.TDP,
                Tech = request.Tech,
                Cores = request.Cores,
            };
            _context.CPUs.Add(cpu);
            await _context.SaveChangesAsync();
            return cpu;
        }
    }
}
