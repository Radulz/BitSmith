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

namespace PCPartsShop.Commands.MOBOCommands.RemoveMOBO
{
    public class RemoveMOBOCommandHandler : IRequestHandler<RemoveMOBOCommand, bool>
    {
        private IComponentRepository<MOBO> _MOBOs;
        public RemoveMOBOCommandHandler()
        {
            
        }
        private void EstablishConnection()
        {
            string connectionString = @"Server=RADULZ-DESKTOP\SQLEXPRESS;Database=Amdaris_PCPartsShop;Trusted_Connection=True;";
            var dbContext = new PCPartsShopContext(connectionString);
            dbContext.Database.EnsureCreated();
            _MOBOs = new MOBORepository(dbContext);
        }
        public Task<bool> Handle(RemoveMOBOCommand request, CancellationToken cancellationToken)
        {
            EstablishConnection();
            bool res = _MOBOs.Delete(request.MOBOId);
            return Task.FromResult(res);
        }
    }
}
