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

namespace PCPartsShop
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Component a, b, c, d, e;
            CPU aux, aux1;
            GPU aux2, aux3;
            MOBO aux4, aux5;
            PSU aux6, aux7;
            RAM aux8, aux9;

            CPURepository proc = new CPURepository();
            GPURepository gproc = new GPURepository();
            MOBORepository boards = new MOBORepository();
            PSURepository punits = new PSURepository();
            RAMRepository sticks = new RAMRepository();
            List<int> f = new List<int>();
            f.Add(2133);
            f.Add(2400);
            f.Add(2666);
            f.Add(3000);
            f.Add(3200);
            
            aux = new CPU("intel", "i7", 250.57, "img1", 2.5, "LGA1200", 14, 2666, 125, 6);
            a = new CPU("intel", "i5", 250.57, "img1", 2.5, "LGA1200", 14, 2666, 125, 6);
            b = new GPU();
            aux2 = new GPU("Nvidia", "GTX1060", 420.33, "img2", 1833, 6, "GDDR5", 8, 150, 223);
            c = new MOBO();
            aux4 = new MOBO("MSI", "MPG", 155.89, "img3", "AM4", "ATX", "B550", f, "DDR4");
            d = new PSU();
            aux6 = new PSU("Corsair", "TX750", 150, "img4", 750, "Non-Modular");
            e = new RAM();
            aux8 = new RAM("HyperX", "Fury", 125.5, "img5", "DDR4", 16, 2400, 1.2);
       
            proc.Add(aux);
            proc.Add((CPU)a);
            gproc.Add(aux2);
            gproc.Add((GPU)b);
            boards.Add(aux4);
            boards.Add((MOBO)c);
            punits.Add(aux6);
            punits.Add((PSU)d);
            sticks.Add(aux8);
            sticks.Add((RAM)e);
            //foreach (CPU i in proc._CPUs)
            //{
            //    Console.WriteLine(i.ComponentId + " " + i.Make + " " + i.Model);
            //}
            //Console.WriteLine();
            //foreach (GPU i in gproc.GPUs)
            //{
            //    Console.WriteLine(i.ComponentId + " " + i.Make + " " + i.Model);
            //}
            //Console.WriteLine();
            //foreach (MOBO i in boards.MOBOs)
            //{
            //    Console.WriteLine(i.ComponentId + " " + i.Make + " " + i.Model);
            //}
            //Console.WriteLine();
            //foreach (PSU i in punits.PSUs)
            //{
            //    Console.WriteLine(i.ComponentId + " " + i.Make + " " + i.Model);
            //}
            //Console.WriteLine();
            //foreach (RAM i in sticks.RAMs)
            //{
            //    Console.WriteLine(i.ComponentId + " " + i.Make + " " + i.Model);
            //}
            //Console.WriteLine();
            //aux1 = proc.GetItem(aux.ComponentId);
            //aux3 = gproc.GetItem(b.ComponentId);
            //aux5 = boards.GetItem(c.ComponentId);
            //aux7 = punits.GetItem(aux6.ComponentId);
            //aux9 = sticks.GetItem(aux8.ComponentId);
            //if (aux1 != null)
            //{
            //    Console.WriteLine(aux1.UniqueId);
            //}
            //else
            //{
            //    Console.WriteLine("This CPU doesn\'t exist");
            //}
            //Console.WriteLine(aux3.UniqueId);
            //Console.WriteLine(aux5.UniqueId);
            //Console.WriteLine(aux7.UniqueId);
            //Console.WriteLine(aux9.UniqueId);

            //var gpu1 = new GPU
            //{
            //    Make = "AMD",
            //    Model = "RX7000XT",
            //    Freq = 2000,
            //    Memory = 8,
            //    MemoryType = "GDDR6",
            //    Tech = 8,
            //    PowerC = 300,
            //    Length = 250,
            //};

            //gpu1.ComponentId = aux2.ComponentId;
            //gproc.Update(gpu1);

            //aux6.ComponentId = d.ComponentId;
            //punits.Update(aux6);
            //Console.WriteLine();
            //foreach (GPU i in gproc.GetAll())
            //{
            //    Console.WriteLine(i.ComponentId + " " + i.Make + " " + i.Model);
            //}
            //foreach (PSU i in punits.GetAll())
            //{
            //    Console.WriteLine(i.ComponentId + " " + i.Make + " " + i.Model);
            //}
            
            var diContainer = new ServiceCollection()
                .AddMediatR(typeof(IComponentRepository<CPU>))
                .AddScoped<IComponentRepository<CPU>, CPURepository>()
                .AddScoped<IComponentRepository<GPU>, GPURepository>()
                .AddScoped<IComponentRepository<MOBO>, MOBORepository>()
                .AddScoped<IComponentRepository<PSU>, PSURepository>()
                .AddScoped<IComponentRepository<RAM>, RAMRepository>()
                .BuildServiceProvider();
            var mediator = diContainer.GetRequiredService<IMediator>();

            var cpu1 = await mediator.Send(new CreateCPUCommand { Make = "AMD", Model = "Ryzen 5", Price = 299.99, Image = "no", Cores = 6, Freq = 5.0, MFreq = 3200, Socket = "AM4", TDP = 65, Tech = 7 });

            Console.WriteLine(cpu1);

            var cpu2 = await mediator.Send(new CreateCPUCommand { Make = "AMD", Model = "Ryzen 7", Price = 399.99, Image = "no", Cores = 8, Freq = 4.8, MFreq = 3200, Socket = "AM4", TDP = 90, Tech = 7 });

            Console.WriteLine(cpu2);

            var getcpus = await mediator.Send(new GetAllCPUsCommand());

            foreach (var i in getcpus)
            {
                Console.WriteLine(i.Make + " " + i.Model);
            }

            var getcpu2 = await mediator.Send(new GetCPUByIdCommand { CPUId = cpu2} );

            Console.WriteLine(getcpu2.Make + " " + getcpu2.Model);

            var delcpu2 = await mediator.Send(new RemoveCPUCommand { CPUId = new Guid() });
            Console.WriteLine(delcpu2);

            var cpu3 = new CPU
            {
                ComponentId = cpu2,
                Make = "AMD",
                Model = "Ryzen 7",
                Price = 359.99,
                Image = "no",
                Cores = 8,
                Freq = 4.8,
                MFreq = 3200,
                Socket = "AM4",
                TDP = 90,
                Tech = 7,
            };

            var updatecpu2 = await mediator.Send(new UpdateCPUCommand { CPUId = cpu2, Make = "AMD", Model = "Ryzen 7", Price = 359.99, Image = "no", Cores = 8, Freq = 4.8, MFreq = 3200, Socket = "AM4", TDP = 90, Tech = 7 });

            Console.WriteLine(updatecpu2);
           
        }
    }
}
