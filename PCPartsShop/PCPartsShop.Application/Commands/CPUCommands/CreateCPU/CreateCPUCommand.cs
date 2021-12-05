using MediatR;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.CPUCommands.CreateCPU
{
    public class CreateCPUCommand : IRequest<CPU>
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
