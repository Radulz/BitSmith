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
        public T GetItem(Guid id);
        public List<T> GetAll();
        public void Delete(Guid id);
        public void Update(Guid id);
    }
}
