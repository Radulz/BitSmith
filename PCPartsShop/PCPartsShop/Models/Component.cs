using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Models
{
    public abstract class Component
    {
        public int ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }


        public Component(string make, string model)
        {
            Make = make;
            Model = model;
        }
        public Component()
        {
           
        }
    }
}
