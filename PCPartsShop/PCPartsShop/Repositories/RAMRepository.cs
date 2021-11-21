using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;

namespace PCPartsShop.Repositories
{
    public class RAMRepository : IComponentRepository<RAM>
    {
        private readonly List<RAM> _RAMs;
        public RAMRepository()
        {
            _RAMs = new List<RAM>();
        }
        public void Add(RAM item)
        {
            _RAMs.Add(item);
        }

        public void Delete(Guid id)
        {
            var ram = _RAMs.FirstOrDefault(item => item.ComponentId == id);
            if (ram != null)
            {
                _RAMs.Remove(ram);
            }
        }

        public IEnumerable<RAM> GetAll()
        {
            return _RAMs;
        }

        public RAM GetItem(Guid id)
        {
            var ram = _RAMs.FirstOrDefault(item => item.ComponentId == id);

            if (ram != null)
            {
                return ram;
            }

            return null;
        }

        public void Update(RAM item)
        {
            var ramindex = _RAMs.FindIndex(x => x.ComponentId == item.ComponentId);
            if (ramindex != -1)
            {
                _RAMs[ramindex] = item;
            }
        }
    }
}
