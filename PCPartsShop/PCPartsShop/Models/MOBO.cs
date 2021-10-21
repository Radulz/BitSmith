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

        private static int c = 0;
        private static void createID()
        {
            c++;
        }
        public MOBO(string make, string model, string socket, string format, string chipset, List<int> freqs, string memorytype) : base (make, model)
        {
            createID();
            ID = c;
            Socket = socket;
            Format = format;
            Chipset = chipset;
            MemoryFreq = freqs;
            MemoryType = memorytype;
        }

        public MOBO()
        {
            createID();
            ID = c;
        }

    }
}
