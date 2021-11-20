using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;

namespace PCPartsShop.Repositories
{
    public class CPURepository : IRepository<CPU>
    {
        public List<CPU> CPUs = new List<CPU>();
        public CPURepository()
        {

        }

        public void Add(CPU item)
        {
            CPUs.Add(item);
        }

        public void Delete(Guid id)
        {
            var cpu = CPUs.FirstOrDefault(item => item.ComponentId == id);
            if (cpu != null)
            {
                CPUs.Remove(cpu);
            }
        }

        public List<CPU> GetAll()
        {
            return CPUs;
        }

        public CPU GetItem(Guid id)
        {
            var cpu = CPUs.FirstOrDefault(item => item.ComponentId == id);
            
            if(cpu != null)
            {
                return cpu;
            }

            return null;
        }

        public void Update(CPU item)
        {
            var cpuindex = CPUs.FindIndex(x => x.ComponentId == item.ComponentId);
            if(cpuindex != -1)
            {
                CPUs[cpuindex] = item;
            }
        }
    }
}
