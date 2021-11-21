using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.PSUCommands.UpdatePSU
{
    public class UpdatePSUCommandHandler : IRequestHandler<UpdatePSUCommand, bool>
    {
        private readonly IComponentRepository<PSU> _PSUs;

        public UpdatePSUCommandHandler(IComponentRepository<PSU> repository)
        {
            _PSUs = repository;
        }

        public Task<bool> Handle(UpdatePSUCommand request, CancellationToken cancellationToken)
        {
            var psu = new PSU
            {
                ComponentId = request.PSUId,
                Make = request.Make,
                Model = request.Model,
                Price = request.Price,
                Image = request.Image,
                Power = request.Power,
                Type = request.Type,
            };
            bool res = _PSUs.Update(psu);
            return Task.FromResult(res);
        }
    }
}
