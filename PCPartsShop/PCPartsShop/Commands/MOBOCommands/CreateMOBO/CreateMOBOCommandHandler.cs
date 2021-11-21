using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.MOBOCommands.CreateMOBO
{
    public class CreateMOBOCommandHandler : IRequestHandler<CreateMOBOCommand, Guid>
    {
        private readonly IComponentRepository<MOBO> _MOBOs;

        public CreateMOBOCommandHandler(IComponentRepository<MOBO> repository)
        {
            _MOBOs = repository;
        }

        public Task<Guid> Handle(CreateMOBOCommand request, CancellationToken cancellationToken)
        {
            var m = new MOBO
            {
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
            _MOBOs.Add(m);
            return Task.FromResult(m.ComponentId);
        }
    }
}
