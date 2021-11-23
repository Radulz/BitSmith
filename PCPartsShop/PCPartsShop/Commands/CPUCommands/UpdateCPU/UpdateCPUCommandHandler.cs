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

namespace PCPartsShop.Commands.CPUCommands.UpdateCPU
{
    public class UpdateCPUCommandHandler : IRequestHandler<UpdateCPUCommand, bool>
    {
        private IComponentRepository<CPU> _CPUs;
        public UpdateCPUCommandHandler()
        {
           
        }
        private void EstablishConnection()
        {
            string connectionString = @"Server=RADULZ-DESKTOP\SQLEXPRESS;Database=Amdaris_PCPartsShop;Trusted_Connection=True;";
            var dbContext = new PCPartsShopContext(connectionString);
            dbContext.Database.EnsureCreated();
            _CPUs = new CPURepository(dbContext);

        }
        public Task<bool> Handle(UpdateCPUCommand request, CancellationToken cancellationToken)
        {
            EstablishConnection();
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
