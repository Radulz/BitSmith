using PCPartsShop.Infrastructure;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.IntegrationTests.Helper
{
    public class Utilities
    {
        public static void InitializeDbForTests(PCPartsShopContext db)
        {
            var cpu1 = new CPU
            {
                Make = "AMD",
                Model = "Ryzen 5",
                Price = 299.99,
                Image = "no",
                Cores = 6,
                Freq = 5.0,
                MFreq = 3200,
                Socket = "AM4",
                TDP = 65,
                Tech = 7
            };

            var cpu2 = new CPU
            {
                Make = "AMD",
                Model = "Ryzen 7",
                Price = 299.99,
                Image = "no",
                Cores = 6,
                Freq = 5.0,
                MFreq = 3200,
                Socket = "AM4",
                TDP = 65,
                Tech = 7
            };

            db.CPUs.Add(cpu1);
            db.CPUs.Add(cpu2);
            db.SaveChanges();

            var gpu1 = new GPU
            {
                Make = "AMD",
                Model = "RX7000XT",
                Price = 1000.99,
                Image = "none",
                Freq = 2000,
                Memory = 8,
                MemoryType = "GDDR6",
                Tech = 8,
                PowerC = 300,
                Length = 250
            };

            var gpu2 = new GPU
            {
                Make = "AMD",
                Model = "RX9000XT",
                Price = 1000.99,
                Image = "none",
                Freq = 2000,
                Memory = 8,
                MemoryType = "GDDR6",
                Tech = 8,
                PowerC = 300,
                Length = 250
            };

            db.GPUs.Add(gpu1);
            db.GPUs.Add(gpu2);
            db.SaveChanges();

            var mobo1 = new MOBO
            {
                Make = "MSI",
                Model = "MPG",
                Price = 155.89,
                Image = "img3",
                Socket = "AM4",
                Format = "ATX",
                Chipset = "B550",
                MemoryFreqInf = 2133,
                MemoryFreqSup = 3200,
                MemoryType = "DDR4"
            };
            var mobo2 = new MOBO
            {
                Make = "MSI",
                Model = "MPG",
                Price = 155.89,
                Image = "img3",
                Socket = "AM4",
                Format = "mATX",
                Chipset = "B550",
                MemoryFreqInf = 2133,
                MemoryFreqSup = 3200,
                MemoryType = "DDR4"
            };

            db.MOBOs.Add(mobo1);
            db.MOBOs.Add(mobo2);
            db.SaveChanges();

            var psu1 = new PSU
            {
                Make = "Corsair",
                Model = "TX750",
                Price = 150,
                Image = "img4",
                Power = 750,
                Type = "Non-Modular"
            };
            var psu2 = new PSU
            {
                Make = "Corsair",
                Model = "TX850",
                Price = 150,
                Image = "img4",
                Power = 750,
                Type = "Non-Modular"
            };

            db.PSUs.Add(psu1);
            db.PSUs.Add(psu2);
            db.SaveChanges();

            var ram1 = new RAM
            {
                Make = "HyperX",
                Model = "Fury",
                Price = 125.5,
                Image = "img5",
                Type = "DDR4",
                Capacity = 16,
                Freq = 2400,
                Voltage = 1.2
            };
            var ram2 = new RAM
            {
                Make = "HyperX",
                Model = "Fury",
                Price = 125.5,
                Image = "img5",
                Type = "DDR5",
                Capacity = 16,
                Freq = 2400,
                Voltage = 1.2
            };

            db.RAMs.Add(ram1);
            db.RAMs.Add(ram2);
            db.SaveChanges();
        }
    }
}
