using System;
using PCPartsShop.Models;
using PCPartsShop.Interfaces;
using PCPartsShop.Repositories;
using System.Collections.Generic;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PCPartsShop.Commands.CPUCommands;
using PCPartsShop.Commands.CPUCommands.GetAllCPUs;
using PCPartsShop.Commands.CPUCommands.GetCPU;
using PCPartsShop.Commands.CPUCommands.RemoveCPU;
using PCPartsShop.Commands.CPUCommands.UpdateCPU;
using PCPartsShop.Commands.GPUCommands.CreateGPU;
using PCPartsShop.Commands.GPUCommands.GetAllGPUs;
using PCPartsShop.Commands.GPUCommands.GetGPU;
using PCPartsShop.Commands.GPUCommands.RemoveGPU;
using PCPartsShop.Commands.GPUCommands.UpdateGPU;
using PCPartsShop.Commands.MOBOCommands.CreateMOBO;
using PCPartsShop.Commands.MOBOCommands.GetAllMOBOs;
using PCPartsShop.Commands.MOBOCommands.GetMOBO;
using PCPartsShop.Commands.MOBOCommands.RemoveMOBO;
using PCPartsShop.Commands.MOBOCommands.UpdateMOBO;
using PCPartsShop.Commands.PSUCommands.CreatePSU;
using PCPartsShop.Commands.PSUCommands.GetAllPSUs;
using PCPartsShop.Commands.PSUCommands.GetPSU;
using PCPartsShop.Commands.PSUCommands.RemovePSU;
using PCPartsShop.Commands.PSUCommands.UpdatePSU;
using PCPartsShop.Commands.RAMCommands.CreateRAM;
using PCPartsShop.Commands.RAMCommands.GetAllRAMs;
using PCPartsShop.Commands.RAMCommands.GetRAM;
using PCPartsShop.Commands.RAMCommands.RemoveRAM;
using PCPartsShop.Commands.RAMCommands.UpdateRAM;

namespace PCPartsShop
{
    internal class Program
    {
        private static IMediator _mediator;
        private static ServiceProvider _diContainer;
        private static async Task Main(string[] args)
        {
            string connectionString = @"Server=RADULZ-DESKTOP\SQLEXPRESS;Database=Amdaris_PCPartsShop;Trusted_Connection=True;";
            using var dbContext = new PCPartsShopContext(connectionString);
            dbContext.Database.EnsureCreated();

            ConfigureMediator();
            await TestCPURepo();
            await TestGPURepo();
            await TestMOBORepo();
            await TestPSURepo();
            await TestRAMRepo();
        }

        private static void ConfigureMediator()
        {
            _diContainer = new ServiceCollection()
                .AddMediatR(typeof(IComponentRepository<CPU>))
                .AddScoped<IComponentRepository<CPU>, CPURepository>()
                .AddScoped<IComponentRepository<GPU>, GPURepository>()
                .AddScoped<IComponentRepository<MOBO>, MOBORepository>()
                .AddScoped<IComponentRepository<PSU>, PSURepository>()
                .AddScoped<IComponentRepository<RAM>, RAMRepository>()
                .BuildServiceProvider();
            _mediator = _diContainer.GetRequiredService<IMediator>();
        }

        private static async Task TestCPURepo()
        {

            var cpu1 = await _mediator.Send(new CreateCPUCommand { Make = "AMD", Model = "Ryzen 5", Price = 299.99, Image = "no", Cores = 6, Freq = 5.0, MFreq = 3200, Socket = "AM4", TDP = 65, Tech = 7 });

            Console.WriteLine(cpu1);

            var cpu2 = await _mediator.Send(new CreateCPUCommand { Make = "AMD", Model = "Ryzen 7", Price = 399.99, Image = "no", Cores = 8, Freq = 4.8, MFreq = 3200, Socket = "AM4", TDP = 90, Tech = 7 });

            Console.WriteLine(cpu2);

            var getcpus = await _mediator.Send(new GetAllCPUsQuery());

            foreach (var i in getcpus)
            {
                Console.WriteLine(i.Make + " " + i.Model);
            }

            var getcpu2 = await _mediator.Send(new GetCPUByIdQuery { CPUId = cpu2 });

            Console.WriteLine(getcpu2.Make + " " + getcpu2.Model);

            var delcpu2 = await _mediator.Send(new RemoveCPUCommand { CPUId = cpu1 });
            Console.WriteLine("Remove CPU response: " + delcpu2);

            var updatecpu2 = await _mediator.Send(new UpdateCPUCommand { CPUId = cpu2, Make = "AMD", Model = "Ryzen 7", Price = 359.99, Image = "no", Cores = 8, Freq = 4.8, MFreq = 3200, Socket = "AM4", TDP = 90, Tech = 7 });

            Console.WriteLine("Update CPU response: " + updatecpu2);
            Console.WriteLine();
            Console.WriteLine();
        }
        private static async Task TestGPURepo()
        {
            var gpu1 = await _mediator.Send(new CreateGPUCommand {Make = "AMD", Model = "RX7000XT", Price=1000.99, Image="none", Freq = 2000, Memory = 8, MemoryType = "GDDR6", Tech = 8, PowerC = 300, Length = 250});
            Console.WriteLine(gpu1);

            var gpu2 = await _mediator.Send(new CreateGPUCommand { Make = "Nvidia", Model = "GTX1060", Price = 420.33, Image = "img2", Freq = 1833, Memory = 6, MemoryType = "GDDR5", Tech = 8, PowerC = 150, Length = 223 });
            Console.WriteLine(gpu2);

            var getgpus = await _mediator.Send(new GetAllGPUsQuery());

            foreach (var i in getgpus)
            {
                Console.WriteLine(i.Make + " " + i.Model);
            }

            var getgpu2 = await _mediator.Send(new GetGPUByIdQuery { GPUId = gpu2 });

            Console.WriteLine(getgpu2.Make + " " + getgpu2.Model);

            var delgpu2 = await _mediator.Send(new RemoveGPUCommand { GPUId = gpu2 });
            Console.WriteLine("Remove GPU response: " + delgpu2);

            foreach (var i in getgpus)
            {
                Console.WriteLine(i.Make + " " + i.Model);
            }
            
            var updategpu2 = await _mediator.Send(new UpdateGPUCommand { GPUId = gpu1, Make = "Nvidia", Model = "GTX1060", Price = 420.33, Image = "img2", Freq = 1833, Memory = 6, MemoryType = "GDDR5", Tech = 8, PowerC = 150, Length = 223 });

            Console.WriteLine("Update GPU response: " + updategpu2);
            Console.WriteLine();
            Console.WriteLine();
        }
        private static async Task TestMOBORepo()
        {
            var m1 = await _mediator.Send(new CreateMOBOCommand { Make = "MSI", Model = "MPG", Price = 155.89, Image = "img3", Socket = "AM4", Format = "ATX", Chipset = "B550", MemoryFreqInf = 2133, MemoryFreqSup = 3200, MemoryType = "DDR4" });
            Console.WriteLine(m1);

            var m2 = await _mediator.Send(new CreateMOBOCommand { Make = "Gigabyte", Model = "Aorus elite", Price = 180, Image = "img8", Socket = "LGA1200", Format = "mATX", Chipset = "Z490", MemoryFreqInf = 2133, MemoryFreqSup = 2666, MemoryType = "DDR4" });
            Console.WriteLine(m2);

            var getmobos = await _mediator.Send(new GetAllMOBOsQuery());

            foreach (var i in getmobos)
            {
                Console.WriteLine(i.Make + " " + i.Model);
            }

            var getm2 = await _mediator.Send(new GetMOBOByIdQuery { MOBOId = m2});
            Console.WriteLine("Mobo by id:" + getm2.Make + " " + getm2.Model);

            var delm2 = await _mediator.Send(new RemoveMOBOCommand { MOBOId = m1 });
            Console.WriteLine("Remove mobo response: " + delm2);

            var updatem2 = await _mediator.Send(new UpdateMOBOCommand { MOBOId = m2, Make = "Gigabyte", Model = "Aorus elite", Price = 180, Image = "img8", Socket = "LGA1200", Format = "mATX", Chipset = "Z490", MemoryFreqInf = 2133, MemoryFreqSup = 3200, MemoryType = "DDR4" });
            Console.WriteLine("Update mobo response: " + updatem2);
            Console.WriteLine();
            Console.WriteLine();
        }
        private static async Task TestPSURepo()
        {
            var p1 = await _mediator.Send(new CreatePSUCommand { Make = "Corsair", Model = "TX750", Price = 150, Image = "img4", Power = 750, Type = "Non-Modular" });
            Console.WriteLine(p1);
            var p2 = await _mediator.Send(new CreatePSUCommand { Make = "Gigabyte", Model = "Aorus etc", Price = 175, Image = "img10", Power = 500, Type = "Modular" });
            Console.WriteLine(p2);
            var getpsus = await _mediator.Send(new GetAllPSUsQuery());
            foreach (var item in getpsus)
            {
                Console.WriteLine(item.Make + " " + item.Model);
            }
            var getp1 = await _mediator.Send(new GetPSUByIdQuery { PSUId = p1 });
            Console.WriteLine(getp1.Make + " " + getp1.Model);
            var delp1 = await _mediator.Send(new RemovePSUCommand { PSUId = p1 });
            Console.WriteLine("Remove psu response: " + delp1);
            var updatep2 = await _mediator.Send(new UpdatePSUCommand { PSUId = p2, Make = "Gigabyte", Model = "Aorus PRO", Price = 175, Image = "img10", Power = 500, Type = "Modular" });
            Console.WriteLine("Update psu response: " + updatep2);
            Console.WriteLine();
            Console.WriteLine();
        }
        private static async Task TestRAMRepo()
        {
            var r1 = await _mediator.Send(new CreateRAMCommand { Make = "HyperX", Model = "Fury", Price = 125.5, Image = "img5", Type = "DDR4", Capacity = 16, Freq = 2400, Voltage = 1.2 });
            Console.WriteLine(r1);
            var r2 = await _mediator.Send(new CreateRAMCommand { Make = "AData", Model = "XPG", Price = 100, Image = "none", Type = "DDR4", Capacity = 32, Freq = 3200, Voltage = 1.35 });
            Console.WriteLine(r2);
            var getrams = await _mediator.Send(new GetAllRAMsQuery());
            foreach (var item in getrams)
            {
                Console.WriteLine(item.Make + " " + item.Model);
            }
            var getr2 = await _mediator.Send(new GetRAMByIdQuery { RAMId = r2 });
            Console.WriteLine(getr2.Make + " " + getr2.Model);
            var delr2 = await _mediator.Send(new RemoveRAMCommand { RAMId = r2 });
            Console.WriteLine("Remove ram response: " + delr2);
            var updater1 = await _mediator.Send(new UpdateRAMCommand { RAMId = r1, Make = "AData", Model = "XPG", Price = 100, Image = "none", Type = "DDR4", Capacity = 32, Freq = 3200, Voltage = 1.35 });
            Console.WriteLine("Update ram response: " + updater1);
        }
    }
}
