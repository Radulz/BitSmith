using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.MOBOCommands.UpdateMOBO
{
    public class UpdateMOBOCommand : IRequest<bool>
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
