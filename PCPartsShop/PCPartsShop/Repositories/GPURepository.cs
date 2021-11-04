using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;

namespace PCPartsShop.Repositories
{
    public class GPURepository : IRepository<GPU>
    {
        public List<GPU> GPUs = new List<GPU>();
        public GPURepository()
        {

        }
        public void Add(GPU item)
        {
            GPUs.Add(item);
        }

        public void Delete(Guid id)
        {
            var gpu = GPUs.FirstOrDefault(item => item.UniqueId == id);
            if (gpu != null)
            {
                GPUs.Remove(gpu);
            }
            
        }

        public List<GPU> GetAll()
        {
            return GPUs;
        }

        public GPU GetItem(Guid id)
        {
            var gpu = GPUs.FirstOrDefault(item => item.UniqueId == id);

            if (gpu != null)
            {
                return gpu;
            }

            return null;
        }

        public void Update(GPU item)
        {
            var gpuindex = GPUs.FindIndex(x => x.UniqueId == item.UniqueId);
            if (gpuindex != -1)
            {
                GPUs[gpuindex] = item;
            }
        }
    }
}
