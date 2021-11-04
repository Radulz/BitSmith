using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;

namespace PCPartsShop.Repositories
{
    public class MOBORepository : IRepository<MOBO>
    {
        public List<MOBO> MOBOs = new List<MOBO>();
        public MOBORepository()
        {

        }
        public void Add(MOBO item)
        {
            MOBOs.Add(item);
        }

        public void Delete(Guid id)
        {
            var mobo = MOBOs.FirstOrDefault(item => item.UniqueId == id);
            if (mobo != null)
            {
                MOBOs.Remove(mobo);
            }
        }

        public List<MOBO> GetAll()
        {
            return MOBOs;
        }

        public MOBO GetItem(Guid id)
        {
            var mobo = MOBOs.FirstOrDefault(item => item.UniqueId == id);

            if (mobo != null)
            {
                return mobo;
            }

            return null;
        }

        public void Update(MOBO item)
        {
            var moboindex = MOBOs.FindIndex(x => x.UniqueId == item.UniqueId);
            if (moboindex != -1)
            {
                MOBOs[moboindex] = item;
            }
        }
    }
}
