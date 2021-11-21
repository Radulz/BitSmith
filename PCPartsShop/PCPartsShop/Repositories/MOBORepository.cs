using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;

namespace PCPartsShop.Repositories
{
    public class MOBORepository : IComponentRepository<MOBO>
    {
        private readonly List<MOBO> _MOBOs;
        public MOBORepository()
        {
            _MOBOs = new List<MOBO>();
        }
        public void Add(MOBO item)
        {
            _MOBOs.Add(item);
        }

        public bool Delete(Guid id)
        {
            var mobo = _MOBOs.FirstOrDefault(item => item.ComponentId == id);
            if (mobo != null)
            {
                _MOBOs.Remove(mobo);
                return true;
            }
            return false;
        }

        public IEnumerable<MOBO> GetAll()
        {
            return _MOBOs;
        }

        public MOBO GetItem(Guid id)
        {
            var mobo = _MOBOs.FirstOrDefault(item => item.ComponentId == id);

            if (mobo != null)
            {
                return mobo;
            }

            return null;
        }

        public bool Update(MOBO item)
        {
            var moboindex = _MOBOs.FindIndex(x => x.ComponentId == item.ComponentId);
            if (moboindex != -1)
            {
                _MOBOs[moboindex] = item;
                return true;
            }
            return false;
        }
    }
}
