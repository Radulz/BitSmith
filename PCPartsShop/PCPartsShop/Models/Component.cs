using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Models
{
    public abstract class Component
    {
        public Guid ComponentId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }


        public Component(Guid ID, string make, string model)
        {
            ComponentId = ID;
            Make = make;
            Model = model;
        }
        public Component()
        {
            ComponentId = Guid.NewGuid();
        }
    }
}
