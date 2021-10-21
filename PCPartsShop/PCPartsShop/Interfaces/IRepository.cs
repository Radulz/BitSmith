using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Interfaces
{
    public interface IRepository<T>
    {
        public T Add(T item);
        public T GetItem(int id);
        public List<T> GetAll();
        public T Delete(int id);
        public T Update(int id);
    }
}
