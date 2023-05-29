using MediatR;
using PCPartsShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.SSDCommands.UpdateSSD
{
    public class UpdateSSDCommand : IRequest<SSD>
    {
        public Guid SSDId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int Capacity { get; set; }
        public string Connector { get; set; }
    }
}
