using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPartsShop.Dtos
{
    public class GetGPUDto
    {
        public Guid GPUId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int Frequency { get; set; }
        public int MemoryCapacity { get; set; }
        public string MemoryType { get; set; }
        public int Technology { get; set; }
        public int PowerConsumption { get; set; }
        public int Length { get; set; }
    }
}
