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
        public double Price { get; set; }
        public string Image { get; set; }


        public Component(Guid ID, string make, string model, double price, string img)
        {
            ComponentId = ID;
            Make = make;
            Model = model;
            Price = price;
            Image = img;
        }
        public Component()
        {
            ComponentId = Guid.NewGuid();
        }
    }
}
