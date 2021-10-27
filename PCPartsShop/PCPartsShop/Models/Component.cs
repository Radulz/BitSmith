using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Models
{
    public abstract class Component
    {
        public Guid UniqueId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }


        public Component(Guid ID, string make, string model)
        {
            UniqueId = ID;
            Make = make;
            Model = model;
        }
        public Component()
        {
            UniqueId = Guid.NewGuid();
        }
    }
}
