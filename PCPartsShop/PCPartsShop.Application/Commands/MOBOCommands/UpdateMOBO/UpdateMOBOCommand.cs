using MediatR;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.MOBOCommands.UpdateMOBO
{
    public class UpdateMOBOCommand : IRequest<MOBO>
    {
        public Guid MOBOId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Socket { get; set; }
        public string Format { get; set; }
        public string Chipset { get; set; }
        public int MemoryFreqInf { get; set; }
        public int MemoryFreqSup { get; set; }
        public string MemoryType { get; set; }
    }
}
