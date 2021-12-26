using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPartsShop_WebAPI.Models
{
    public class RAM : Component
    {
        public string Type { get; set; }
        public int Capacity { get; set; } // in GB
        public int Freq { get; set; } // in MHZ
        public double Voltage { get; set; } // in V

        public RAM(string make, string model, double price, string img, string type, int capacity, int frequency, double volts) : base(Guid.NewGuid(), make, model, price, img)
        {
            Type = type;
            Capacity = capacity;
            Freq = frequency;
            Voltage = volts;
            ComponentType = "RAM";
        }

        public RAM() : base()
        {
            ComponentType = "RAM";
        }
    }
}
