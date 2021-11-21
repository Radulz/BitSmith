using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.RAMCommands.CreateRAM
{
    public class CreateRAMCommandHandler : IRequestHandler<CreateRAMCommand, Guid>
    {
        private readonly IComponentRepository<RAM> _RAMs;

        public CreateRAMCommandHandler(IComponentRepository<RAM> repository)
        {
            _RAMs = repository;
        }

        public Task<Guid> Handle(CreateRAMCommand request, CancellationToken cancellationToken)
        {
            var r = new RAM
            {
                Make = request.Make,
                Model = request.Model,
                Price = request.Price,
                Image = request.Image,
                Capacity = request.Capacity,
                Freq = request.Freq,
                Type = request.Type,
                Voltage = request.Voltage,
            };
            _RAMs.Add(r);
            return Task.FromResult(r.ComponentId);
        }
    }
}
