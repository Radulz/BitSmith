using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPartsShop_WebAPI.Models
{
    public class PSU : Component
    {
        public int Power { get; set; } // in W
        public string Type { get; set; }

        public PSU(string make, string model, double price, string img, int power, string type) : base(Guid.NewGuid(), make, model, price, img)
        {

            Power = power;
            Type = type;
            ComponentType = "PSU";
        }

        public PSU() : base()
        {
            ComponentType = "PSU";
        }
    }
}
