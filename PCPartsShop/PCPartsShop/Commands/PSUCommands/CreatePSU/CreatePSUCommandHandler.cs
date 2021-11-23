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

namespace PCPartsShop.Commands.PSUCommands.CreatePSU
{
    public class CreatePSUCommandHandler : IRequestHandler<CreatePSUCommand, Guid>
    {
        private IComponentRepository<PSU> _PSUs;

        public CreatePSUCommandHandler()
        {
        
        }
        private void EstablishConnection()
        {
            string connectionString = @"Server=RADULZ-DESKTOP\SQLEXPRESS;Database=Amdaris_PCPartsShop;Trusted_Connection=True;";
            var dbContext = new PCPartsShopContext(connectionString);
            dbContext.Database.EnsureCreated();
            _PSUs = new PSURepository(dbContext);
        }

        public Task<Guid> Handle(CreatePSUCommand request, CancellationToken cancellationToken)
        {
            EstablishConnection();
            var psu = new PSU
            {
                Make = request.Make,
                Model = request.Model,
                Price = request.Price,
                Image = request.Image,
                Power = request.Power,
                Type = request.Type,
            };
            _PSUs.Add(psu);
            return Task.FromResult(psu.ComponentId);
        }
    }
}
