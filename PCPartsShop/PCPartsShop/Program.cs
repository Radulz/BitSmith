using System;
using PCPartsShop.Models;
using PCPartsShop.Interfaces;
using PCPartsShop.Repositories;

namespace PCPartsShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Component a, b, c, d, e, f, g, h;
            a = new CPU();
            b = new CPU();
            c = new CPU();
            d = new GPU();
            e = new MOBO();
            f = new PSU();
            g = new RAM();
            h = new RAM();
            Console.WriteLine(b.ID + " " + e.ID + " " + f.ID + " " + h.ID);
            
        }
    }
}
