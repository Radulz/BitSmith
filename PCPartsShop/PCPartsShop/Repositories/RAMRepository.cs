using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;

namespace PCPartsShop.Repositories
{
    public class RAMRepository : IComponentRepository<RAM>
    {
        private readonly PCPartsShopContext _dbContext;
        public RAMRepository(PCPartsShopContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(RAM item)
        {
            _dbContext.RAMs.Add(item);
            _dbContext.SaveChanges();
        }

        public bool Delete(Guid id)
        {
            var ram = _dbContext.RAMs.FirstOrDefault(item => item.ComponentId == id);
            if (ram != null)
            {
                _dbContext.RAMs.Remove(ram);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<RAM> GetAll()
        {
            return _dbContext.RAMs;
        }

        public RAM GetItem(Guid id)
        {
            var ram = _dbContext.RAMs.FirstOrDefault(item => item.ComponentId == id);

            if (ram != null)
            {
                return ram;
            }

            return null;
        }

        public bool Update(RAM item)
        {
            var ram = _dbContext.RAMs.FirstOrDefault(x => x.ComponentId == item.ComponentId);
            if (ram != null)
            {
                ram.Make = item.Make;
                ram.Model = item.Model;
                ram.Price = item.Price;
                ram.Image = item.Image;
                ram.Type = item.Type;
                ram.Capacity = item.Capacity;
                ram.Freq = item.Freq;
                ram.Voltage = item.Voltage;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
