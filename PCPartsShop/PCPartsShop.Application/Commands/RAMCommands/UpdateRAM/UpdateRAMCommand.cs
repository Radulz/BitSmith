using MediatR;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.RAMCommands.UpdateRAM
{
    public class UpdateRAMCommand : IRequest<RAM>
    {
        public Guid RAMId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Freq { get; set; }
        public double Voltage { get; set; }
    }
}
