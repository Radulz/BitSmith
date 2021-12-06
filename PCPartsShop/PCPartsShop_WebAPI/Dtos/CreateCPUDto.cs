using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPartsShop.Dtos
{
    public class CreateCPUDto
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public double Frequency { get; set; } 
        public string Socket { get; set; }
        public int Technology { get; set; } 
        public int MemoryFrequency { get; set; } 
        public int ThermalDesignPower { get; set; } 
        public int NumberOfCores { get; set; }
    }
}
