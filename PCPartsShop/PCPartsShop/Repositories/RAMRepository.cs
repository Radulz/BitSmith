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

        public void Delete(int id)
        {
            foreach(RAM r in RAMs)
            {
                if(r.ID == id)
                {
                    RAMs.Remove(r);
                    return;
                }
            }
        }

        public List<RAM> GetAll()
        {
            return RAMs;
        }

        public RAM GetItem(int id)
        {
            foreach (RAM r in RAMs)
            {
                if (r.ID == id)
                {
                    return r;
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
