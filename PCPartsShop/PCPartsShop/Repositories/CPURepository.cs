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

        public void Delete(int id)
        {

            foreach (CPU c in CPUs)
            {
                if(c.ID == id)
                {
                    CPUs.Remove(c);
                    return;
                }
            }
        }

        public List<CPU> GetAll()
        {
            return CPUs;
        }

        public CPU GetItem(int id)
        {
            foreach (CPU c in CPUs)
            {
                if (c.ID == id)
                {
                    return c;
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
