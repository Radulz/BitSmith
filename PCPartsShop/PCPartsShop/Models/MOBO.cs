using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Models
{
    public class MOBO : Component
    {
        public string Socket { get; set; }
        public string Format { get; set; }
        public string Chipset { get; set; }
        public List<int> MemoryFreq { get; set; } // all in MHz
        public string MemoryType { get; set; }

        public MOBO(string make, string model, string socket, string format, string chipset, List<int> freqs, string memorytype) : base (Guid.NewGuid(), make, model)
        {
            Socket = socket;
            Format = format;
            Chipset = chipset;
            MemoryFreq = freqs;
            MemoryType = memorytype;
        }

        public MOBO() : base()
        {
            
        }

    }
}
