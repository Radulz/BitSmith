using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Domain.Models
{
    public class Cooler : Component
    {
        public int Height { get; set; }
        public string CoolingType { get; set; } = "Air";
        public int RadiatorLength { get; set; } = 0;
        public int NumberOfHeatPipes { get; set; }

        public Cooler() : base()
        {
            ComponentType = "COOLER";
        }
    }
}
