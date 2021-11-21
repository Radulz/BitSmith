using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
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
        private readonly IComponentRepository<PSU> _PSUs;

        public CreatePSUCommandHandler(IComponentRepository<PSU> repository)
        {
            _PSUs = repository;
        }

        public Task<Guid> Handle(CreatePSUCommand request, CancellationToken cancellationToken)
        {
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
