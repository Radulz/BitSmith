using MediatR;
using PCPartsShop.Domain.Models;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.CaseCommands.CreateCase
{
    public class CreateCaseCommandHandler : IRequestHandler<CreateCaseCommand, Case>
    {
        private readonly PCPartsShopContext _dbContext;
        public CreateCaseCommandHandler(PCPartsShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Case> Handle(CreateCaseCommand request, CancellationToken cancellationToken)
        {
            var pcCase = new Case
            {
                Make = request.Make,
                Model = request.Model,
                Price = request.Price,
                Image = request.Image,
                CaseType = request.CaseType,
                PSUPosition = request.PSUPosition,
                GPUMaximumLength = request.GPUMaximumLength,
                RadiatorSupport = request.RadiatorSupport,
                RadiatorSupportLength = request.RadiatorSupport ? request.RadiatorSupportLength : 0,
                CoolerMaximumHeight = request.CoolerMaximumHeight,
            };

            _dbContext.Cases.Add(pcCase);
            await _dbContext.SaveChangesAsync();
            return pcCase;
        }
    }
}
