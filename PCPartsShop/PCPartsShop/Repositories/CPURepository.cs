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
        private readonly PCPartsShopContext _dbContext;
        public CPURepository(PCPartsShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(CPU item)
        {
            _dbContext.CPUs.Add(item);
            _dbContext.SaveChanges();
        }

        public bool Delete(Guid id)
        {
            var cpu = _dbContext.CPUs.FirstOrDefault(item => item.ComponentId == id);
            if (cpu != null)
            {
                _dbContext.CPUs.Remove(cpu);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<CPU> GetAll()
        {
            return _dbContext.CPUs;
        }

        public CPU GetItem(Guid id)
        {
            var cpu = _dbContext.CPUs.FirstOrDefault(item => item.ComponentId == id);
            
            if(cpu != null)
            {
                return cpu;
            }

            return null;
        }

        public bool Update(CPU item)
        {
            var cpu = _dbContext.CPUs.FirstOrDefault(i => i.ComponentId == item.ComponentId);
            if (cpu != null)
            {
                cpu.Make = item.Make;
                cpu.Model = item.Model;
                cpu.Price = item.Price;
                cpu.Image = item.Image;
                cpu.Freq = item.Freq;
                cpu.MFreq = item.MFreq;
                cpu.Socket = item.Socket;
                cpu.Tech = item.Tech;
                cpu.TDP = item.TDP;
                cpu.Cores = item.Cores;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
