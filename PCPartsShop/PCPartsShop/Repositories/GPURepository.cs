using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;

namespace PCPartsShop.Repositories
{
    public class GPURepository : IComponentRepository<GPU>
    {
        private readonly PCPartsShopContext _dbContext;
        public GPURepository(PCPartsShopContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(GPU item)
        {
            _dbContext.GPUs.Add(item);
            _dbContext.SaveChanges();
        }

        public bool Delete(Guid id)
        {
            var gpu = _dbContext.GPUs.FirstOrDefault(item => item.ComponentId == id);
            if (gpu != null)
            {
                _dbContext.GPUs.Remove(gpu);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
            
        }

        public IEnumerable<GPU> GetAll()
        {
            return _dbContext.GPUs;
        }

        public GPU GetItem(Guid id)
        {
            var gpu = _dbContext.GPUs.FirstOrDefault(item => item.ComponentId == id);

            if (gpu != null)
            {
                return gpu;
            }

            return null;
        }

        public bool Update(GPU item)
        {
            var gpu = _dbContext.GPUs.FirstOrDefault(i => i.ComponentId == item.ComponentId);
            if (gpu != null)
            {
                gpu.Make = item.Make;
                gpu.Model = item.Model;
                gpu.Price = item.Price;
                gpu.Image = item.Image;
                gpu.Freq = item.Freq;
                gpu.Memory = item.Memory;
                gpu.MemoryType = item.MemoryType;
                gpu.PowerC = item.PowerC;
                gpu.Tech = item.Tech;
                gpu.Length = item.Length;
                return true;
            }
            return false;
        }
    }
}
