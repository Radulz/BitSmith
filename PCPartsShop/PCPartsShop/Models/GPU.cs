using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Models
{
    public class GPU : Component
    {
        public int Freq { get; set;} // in MHz
        public int Memory { get; set; } // in GB
        public string MemoryType { get; set; }
        public int Tech { get; set; } // in nm
        public int PowerC { get; set; } // in W
        public int Length { get; set; } // in cm

        private static int c = 0;
        private static void createID()
        {
            c++;
        }

        public GPU(string make, string model, int frequency, int capacity, string type, int tech, int power, int length) : base(make, model)
        {
            createID();
            ID = c;
            Freq = frequency;
            Memory = capacity;
            MemoryType = type;
            Tech = tech;
            PowerC = power;
            Length = length;
        }
        public GPU() : base()
        {
            createID();
            ID = c;
        }
    }
}
