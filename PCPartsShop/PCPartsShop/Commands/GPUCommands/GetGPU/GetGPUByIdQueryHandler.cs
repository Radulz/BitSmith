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

namespace PCPartsShop.Commands.GPUCommands.GetGPU
{
    public class GetGPUByIdQueryHandler : IRequestHandler<GetGPUByIdQuery, GPU>
    {
        private IComponentRepository<GPU> _GPUs;
        public GetGPUByIdQueryHandler()
        {
           
        }
        private void EstablishConnection()
        {
            string connectionString = @"Server=RADULZ-DESKTOP\SQLEXPRESS;Database=Amdaris_PCPartsShop;Trusted_Connection=True;";
            var dbContext = new PCPartsShopContext(connectionString);
            dbContext.Database.EnsureCreated();
            _GPUs = new GPURepository(dbContext);

        }
        public Task<GPU> Handle(GetGPUByIdQuery request, CancellationToken cancellationToken)
        {
            EstablishConnection();
            var gpu = _GPUs.GetItem(request.GPUId);
            return Task.FromResult(gpu);
        }
    }
}
