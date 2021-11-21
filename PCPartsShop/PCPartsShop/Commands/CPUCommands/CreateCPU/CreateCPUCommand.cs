using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.CPUCommands
{
    public class CreateCPUCommand : IRequest<Guid>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public double Freq { get; set; }
        public string Socket { get; set; }
        public int Tech { get; set; }
        public int MFreq { get; set; }
        public int TDP { get; set; } 
        public int Cores { get; set; }

    }
}
