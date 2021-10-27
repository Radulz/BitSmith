using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Models
{
    public class RAM : Component
    {
        public string Type { get; set; }
        public int Capacity { get; set; } // in GB
        public int Freq { get; set; } // in MHZ
        public double Voltage { get; set; } // in V

        public RAM(string make, string model, string type, int capacity, int frequency, double volts) : base(Guid.NewGuid(), make, model)
        {
            Type = type;
            Capacity = capacity;
            Freq = frequency;
            Voltage = volts;
        }

        public RAM() : base()
        {
            
        }
    }
}
