using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;

namespace PCPartsShop.Repositories
{
    public class CPURepository : IComponentRepository<CPU>
    {
        private readonly List<CPU> _CPUs;
        public CPURepository()
        {
            _CPUs = new List<CPU>();
        }

        public void Add(CPU item)
        {
            _CPUs.Add(item);
        }

        public bool Delete(Guid id)
        {
            var cpu = _CPUs.FirstOrDefault(item => item.ComponentId == id);
            if (cpu != null)
            {
                _CPUs.Remove(cpu);
                return true;
            }
            return false;
        }

        public IEnumerable<CPU> GetAll()
        {
            return _CPUs;
        }

        public CPU GetItem(Guid id)
        {
            var cpu = _CPUs.FirstOrDefault(item => item.ComponentId == id);
            
            if(cpu != null)
            {
                return cpu;
            }

            return null;
        }

        public bool Update(CPU item)
        {
            var cpuindex = _CPUs.FindIndex(x => x.ComponentId == item.ComponentId);
            if(cpuindex != -1)
            {
                _CPUs[cpuindex] = item;
                return true;
            }
            return false;
        }
    }
}
