using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.RAMCommands.UpdateRAM
{
    public class UpdateRAMCommandHandler : IRequestHandler<UpdateRAMCommand, bool>
    {
        private readonly IComponentRepository<RAM> _RAMs;

        public UpdateRAMCommandHandler(IComponentRepository<RAM> repository)
        {
            _RAMs = repository;
        }
        public Task<bool> Handle(UpdateRAMCommand request, CancellationToken cancellationToken)
        {
            var r = new RAM
            {
                ComponentId = request.RAMId,
                Make = request.Make,
                Model = request.Model,
                Price = request.Price,
                Image = request.Image,
                Capacity = request.Capacity,
                Freq = request.Freq,
                Type = request.Type,
                Voltage = request.Voltage,
            };
            bool res = _RAMs.Update(r);
            return Task.FromResult(res);
        }
    }
}
