using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Domain.Models
{
    public class SSD : Component
    {
        public int Capacity { get; set; }
        public string Connector { get; set; }

        public SSD() : base()   
        {
            ComponentType = "SSD";
        }
    }
}
