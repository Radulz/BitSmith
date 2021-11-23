using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using PCPartsShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.CPUCommands
{
    public class CreateCPUCommandHandler : IRequestHandler<CreateCPUCommand, Guid>
    {
        private IComponentRepository<CPU> _cpurepo;

        public CreateCPUCommandHandler()
        {
            
        }
        private void EstablishConnection()
        {
            string connectionString = @"Server=RADULZ-DESKTOP\SQLEXPRESS;Database=Amdaris_PCPartsShop;Trusted_Connection=True;";
            var dbContext = new PCPartsShopContext(connectionString);
            dbContext.Database.EnsureCreated();
            _cpurepo = new CPURepository(dbContext);

        }
        public Task<Guid> Handle(CreateCPUCommand request, CancellationToken cancellationToken)
        {
            EstablishConnection();
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
            _cpurepo.Add(cpu);
            return Task.FromResult(cpu.ComponentId);
        }
    }
}
