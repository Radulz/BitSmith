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

namespace PCPartsShop.Commands.GPUCommands.RemoveGPU
{
    public class RemoveGPUCommandHandler : IRequestHandler<RemoveGPUCommand, bool>
    {
        private IComponentRepository<GPU> _GPUs;
        public RemoveGPUCommandHandler()
        {
           
        }
        private void EstablishConnection()
        {
            string connectionString = @"Server=RADULZ-DESKTOP\SQLEXPRESS;Database=Amdaris_PCPartsShop;Trusted_Connection=True;";
            var dbContext = new PCPartsShopContext(connectionString);
            dbContext.Database.EnsureCreated();
            _GPUs = new GPURepository(dbContext);

        }
        public Task<bool> Handle(RemoveGPUCommand request, CancellationToken cancellationToken)
        {
            EstablishConnection();
            bool res = _GPUs.Delete(request.GPUId);
            return Task.FromResult(res);
        }
    }
}
