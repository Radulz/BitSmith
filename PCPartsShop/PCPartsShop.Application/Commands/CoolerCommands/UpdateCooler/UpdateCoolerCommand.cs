using MediatR;
using PCPartsShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.CoolerCommands.UpdateCooler
{
    public class UpdateCoolerCommand : IRequest<Cooler>
    {
        public Guid CoolerId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int Height { get; set; }
        public string CoolingType { get; set; } = "Air";
        public int RadiatorLength { get; set; } = 0;
        public int NumberOfHeatPipes { get; set; }
    }
}
