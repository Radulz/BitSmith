using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Interfaces
{
    public interface IRepository<T>
    {
        public void Add(T item);
        public T GetItem(int id);
        public List<T> GetAll();
        public void Delete(int id);
        public void Update(int id);
    }
}
