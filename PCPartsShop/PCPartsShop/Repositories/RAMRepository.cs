using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;

namespace PCPartsShop.Repositories
{
    public class RAMRepository : IRepository<RAM>
    {
        public List<RAM> RAMs = new List<RAM>();
        public RAMRepository()
        {

        }
        public void Add(RAM item)
        {
            RAMs.Add(item);
        }

        public void Delete(Guid id)
        {
            var ram = RAMs.First(item => item.UniqueId == id);
            if (ram != null)
            {
                RAMs.Remove(ram);
            }
        }

        public List<RAM> GetAll()
        {
            return RAMs;
        }

        public RAM GetItem(Guid id)
        {
            var ram = RAMs.First(item => item.UniqueId == id);

            if (ram != null)
            {
                return ram;
            }

            return null;
        }

        public void Update(RAM item)
        {
            var ramindex = RAMs.FindIndex(x => x.UniqueId == item.UniqueId);
            if (ramindex != -1)
            {
                RAMs[ramindex] = item;
            }
        }
    }
}
