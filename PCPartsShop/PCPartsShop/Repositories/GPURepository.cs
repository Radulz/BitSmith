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

        public void Delete(int id)
        {
            foreach(GPU g in GPUs)
            {
                if(g.ID == id)
                {
                    GPUs.Remove(g);
                    return;
                }
            }
        }

        public List<GPU> GetAll()
        {
            return GPUs;
        }

        public GPU GetItem(int id)
        {
            foreach (GPU g in GPUs)
            {
                if (g.ID == id)
                {
                    GPUs.Remove(g);
                    return g;
                }
            }
            return null;
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
