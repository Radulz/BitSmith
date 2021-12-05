using MediatR;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.PSUCommands.UpdatePSU
{
    public class UpdatePSUCommand : IRequest<PSU>
    {
        public Guid PSUId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int Power { get; set; }
        public string Type { get; set; }
    }
}
