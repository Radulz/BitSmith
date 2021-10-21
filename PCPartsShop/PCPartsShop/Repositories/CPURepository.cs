using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;

namespace PCPartsShop.Repositories
{
    public class CPURepository<T> : IRepository<T> where T : CPU
    {
        public List<T> CPUs;

        void IRepository<T>.Add(T item)
        {
            CPUs.Add(item);
        }

        void IRepository<T>.Delete(int id)
        {

            foreach (T c in CPUs)
            {
                if(c.ID == id)
                {
                    CPUs.Remove(c);
                    return;
                }
            }
        }

        List<T> IRepository<T>.GetAll()
        {
            return CPUs;
        }

        T IRepository<T>.GetItem(int id)
        {
            foreach (T c in CPUs)
            {
                if (c.ID == id)
                {
                    return c;
                }
            }
            return null;
        }

        void IRepository<T>.Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
