using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPartsShop.Dtos
{
    public class CreateMOBODto
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Socket { get; set; }
        public string Format { get; set; }
        public string Chipset { get; set; }
        public int LowestFrequencySupported { get; set; }
        public int HighestFrequencySupported { get; set; }
        public string MemoryType { get; set; }
    }
}
