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
        private readonly List<GPU> _GPUs;
        public GPURepository()
        {
            _GPUs = new List<GPU>();
        }
        public void Add(GPU item)
        {
            _GPUs.Add(item);
        }

        public void Delete(Guid id)
        {
            var gpu = _GPUs.FirstOrDefault(item => item.ComponentId == id);
            if (gpu != null)
            {
                _GPUs.Remove(gpu);
            }
            
        }

        public IEnumerable<GPU> GetAll()
        {
            return _GPUs;
        }

        public GPU GetItem(Guid id)
        {
            var gpu = _GPUs.FirstOrDefault(item => item.ComponentId == id);

            if (gpu != null)
            {
                return gpu;
            }

            return null;
        }

        public void Update(GPU item)
        {
            var gpuindex = _GPUs.FindIndex(x => x.ComponentId == item.ComponentId);
            if (gpuindex != -1)
            {
                _GPUs[gpuindex] = item;
            }
        }
    }
}
