using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCPartsShop.Models;

namespace PCPartsShop.Interfaces
{
    public interface IComponentRepository<T> where T : Component
    {
        public void Add(T item);
        public T GetItem(Guid id);
        public IEnumerable<T> GetAll();
        public void Delete(Guid id);
        public void Update(T item);
    }
}
