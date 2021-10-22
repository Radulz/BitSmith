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

        public void Delete(int id)
        {
            foreach (MOBO m in MOBOs)
            {
                if (m.ID == id)
                {
                    MOBOs.Remove(m);
                    return;
                }
            }
        }

        public List<MOBO> GetAll()
        {
            return MOBOs;
        }

        public MOBO GetItem(int id)
        {
            foreach (MOBO m in MOBOs)
            {
                if (m.ID == id)
                {
                    return m;
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
