using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Models
{
    public class PSU : Component
    {
        public int Power { get; set; } // in W
        public string Type { get; set; }

        private static int c = 0;
        private static void createID()
        {
            c++;
        }
        public PSU(string make, string model, int power, string type) : base(make, model)
        {
            createID();
            ID = c;
            Power = power;
            Type = type;
        }

        public PSU()
        {
            createID();
            ID = c;
        }
    }
}
