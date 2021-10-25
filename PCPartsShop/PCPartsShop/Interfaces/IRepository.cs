using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCPartsShop.Models;

namespace PCPartsShop.Interfaces
{
    public interface IRepository<T> where T : Component
    {
        public void Add(T item);
        public T GetItem(int id);
        public List<T> GetAll();
        public void Delete(int id);
        public void Update(int id);
    }
}
