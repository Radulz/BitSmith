using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Models
{
    public class CPU : Component
    {
        public double Freq { get; set; } // ing GHz
        public string Socket { get; set; }
        public int Tech { get; set; } // in nm
        public int MFreq { get; set; } // MHz
        public int TDP { get; set; } // in W
        public int Cores { get; set; }

        public CPU(string make, string model, double frequency, string socket, int tech, int mfreq, int tdp, int corenr) : base(Guid.NewGuid(), make, model)
        {
            Freq = frequency;
            Socket = socket;
            Tech = tech;
            MFreq = mfreq;
            TDP = tdp;
            Cores = corenr;
        }
        public CPU() : base()
        {
            
        }
    }
}
