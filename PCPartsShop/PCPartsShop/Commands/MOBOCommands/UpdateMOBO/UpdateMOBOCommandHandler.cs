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

namespace PCPartsShop.Commands.MOBOCommands.UpdateMOBO
{
    public class UpdateMOBOCommandHandler : IRequestHandler<UpdateMOBOCommand, bool>
    {
        private  IComponentRepository<MOBO> _MOBOs;
        public UpdateMOBOCommandHandler()
        {
            
        }
        private void EstablishConnection()
        {
            string connectionString = @"Server=RADULZ-DESKTOP\SQLEXPRESS;Database=Amdaris_PCPartsShop;Trusted_Connection=True;";
            var dbContext = new PCPartsShopContext(connectionString);
            dbContext.Database.EnsureCreated();
            _MOBOs = new MOBORepository(dbContext);
        }
        public Task<bool> Handle(UpdateMOBOCommand request, CancellationToken cancellationToken)
        {
            EstablishConnection();
            var m = new MOBO
            {
                ComponentId = request.MOBOId,
                Make = request.Make,
                Model = request.Model,
                Price = request.Price,
                Image = request.Image,
                MemoryFreqInf = request.MemoryFreqInf,
                MemoryFreqSup = request.MemoryFreqSup,
                MemoryType = request.MemoryType,
                Format = request.Format,
                Chipset = request.Chipset,
                Socket = request.Socket,
            };
            bool res = _MOBOs.Update(m);
            return Task.FromResult(res);
        }
    }
}
