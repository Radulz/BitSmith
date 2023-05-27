using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Domain.Dtos
{
    public class FullSpecificationComponentDto
    {
        public Guid ComponentId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string ComponentType { get; set; }
        public int Qty { get; set; }
        public double Frequency { get; set; }
        public string Socket { get; set; }
        public int Technology { get; set; }
        public int MemoryFrequency { get; set; }
        public int ThermalDesignPower { get; set; }
        public int NumberOfCores { get; set; }
        public int MemoryCapacity { get; set; }
        public string MemoryType { get; set; }
        public int PowerConsumption { get; set; }
        public int Length { get; set; }
        public string Format { get; set; }
        public string Chipset { get; set; }
        public int LowestFrequencySupported { get; set; }
        public int HighestFrequencySupported { get; set; }
        public int Power { get; set; }
        public string Modularity { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public double Voltage { get; set; }
    }
}
