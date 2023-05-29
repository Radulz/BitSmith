using MediatR;
using PCPartsShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.CaseCommands.CreateCase
{
    public class CreateCaseCommand : IRequest<Case>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int GPUMaximumLength { get; set; }
        public int CoolerMaximumHeight { get; set; }
        public bool RadiatorSupport { get; set; } = false;
        public int RadiatorSupportLength { get; set; } = 0;
        public string CaseType { get; set; }
        public string PSUPosition { get; set; }
    }
}
