﻿using MediatR;
using PCPartsShop.Domain.Models;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.CoolerCommands.CreateCooler
{
    public class CreateCoolerCommandHandler : IRequestHandler<CreateCoolerCommand, Cooler>
    {
        private readonly PCPartsShopContext _dbContext;
        public CreateCoolerCommandHandler(PCPartsShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Cooler> Handle(CreateCoolerCommand request, CancellationToken cancellationToken)
        {
            var cooler = new Cooler
            {
                Make = request.Make,
                Model = request.Model,
                Price = request.Price,
                Image = request.Image,
                CoolingType = request.CoolingType,
                Height = request.CoolingType == "Air" ? request.Height : 0,
                NumberOfHeatPipes = request.CoolingType == "Air" ? request.NumberOfHeatPipes : 0,
                RadiatorLength = request.CoolingType == "Liquid" ? request.RadiatorLength : 0,
            };

            _dbContext.Coolers.Add(cooler);
            await _dbContext.SaveChangesAsync();
            return cooler;
        }
    }
}
