using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPartsShop_WebAPI.Models
{
    public class MOBO : Component
    {
        public string Socket { get; set; }
        public string Format { get; set; }
        public string Chipset { get; set; }
        public int MemoryFreqInf { get; set; }
        public int MemoryFreqSup { get; set; }
        public string MemoryType { get; set; }

        public MOBO(string make, string model, double price, string img, string socket, string format, string chipset, int inf, int sup, string memorytype) : base(Guid.NewGuid(), make, model, price, img)
        {
            Socket = socket;
            Format = format;
            Chipset = chipset;
            MemoryFreqInf = inf;
            MemoryFreqSup = sup;
            MemoryType = memorytype;
        }

        public MOBO() : base()
        {

        }
    }
}
