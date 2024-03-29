﻿using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using PCPartsShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.GPUCommands.CreateGPU
{
    public class CreateGPUCommandHandler : IRequestHandler<CreateGPUCommand, Guid>
    {
        private IComponentRepository<GPU> _GPUs;

        public CreateGPUCommandHandler()
        {
           
        }
        private void EstablishConnection()
        {
            string connectionString = @"Server=RADULZ-DESKTOP\SQLEXPRESS;Database=Amdaris_PCPartsShop;Trusted_Connection=True;";
            var dbContext = new PCPartsShopContext(connectionString);
            dbContext.Database.EnsureCreated();
            _GPUs = new GPURepository(dbContext);

        }
        public Task<Guid> Handle(CreateGPUCommand request, CancellationToken cancellationToken)
        {
            EstablishConnection();
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
            _GPUs.Add(gpu);
            return Task.FromResult(gpu.ComponentId);
        }
    }
}
