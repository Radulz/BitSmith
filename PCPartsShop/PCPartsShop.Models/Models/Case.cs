using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Domain.Models
{
    public class Case : Component
    {
        public int GPUMaximumLength { get; set; }
        public int CoolerMaximumHeight { get; set; }
        public bool RadiatorSupport { get; set; } = false;
        public int RadiatorSupportLength { get; set; } = 0;
        public string CaseType { get; set; }
        public string PSUPosition { get; set; }
        public Case() : base()
        {
            ComponentType = "CASE";
        }
    }
}
