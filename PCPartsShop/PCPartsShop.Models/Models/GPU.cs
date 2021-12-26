using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPartsShop_WebAPI.Models
{
    public class GPU : Component
    {
        public int Freq { get; set; } // in MHz
        public int Memory { get; set; } // in GB
        public string MemoryType { get; set; }
        public int Tech { get; set; } // in nm
        public int PowerC { get; set; } // in W
        public int Length { get; set; } // in cm

        public GPU(string make, string model, double price, string img, int frequency, int capacity, string type, int tech, int power, int length) : base(Guid.NewGuid(), make, model, price, img)
        {
            Freq = frequency;
            Memory = capacity;
            MemoryType = type;
            Tech = tech;
            PowerC = power;
            Length = length;
            ComponentType = "GPU";
        }
        public GPU() : base()
        {
            ComponentType = "GPU";
        }
    }
}
