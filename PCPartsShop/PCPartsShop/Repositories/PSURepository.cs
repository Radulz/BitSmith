using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;

namespace PCPartsShop.Repositories
{
    public class PSURepository : IComponentRepository<PSU>
    {
        private readonly PCPartsShopContext _dbContext;
        public PSURepository(PCPartsShopContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(PSU item)
        {
            _dbContext.PSUs.Add(item);
            _dbContext.SaveChanges();
        }

        public bool Delete(Guid id)
        {
            var psu = _dbContext.PSUs.FirstOrDefault(item => item.ComponentId == id);
            if (psu != null)
            {
                _dbContext.PSUs.Remove(psu);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<PSU> GetAll()
        {
            return _dbContext.PSUs;
        }

        public PSU GetItem(Guid id)
        {
            var psu = _dbContext.PSUs.FirstOrDefault(item => item.ComponentId == id);

            if (psu != null)
            {
                return psu;
            }

            return null;
        }

        public bool Update(PSU item)
        {
            var psu = _dbContext.PSUs.FirstOrDefault(x => x.ComponentId == item.ComponentId);
            if (psu != null)
            {
                psu.Make = item.Make;
                psu.Model = item.Model;
                psu.Price = item.Price;
                psu.Image = item.Image;
                psu.Power = item.Power;
                psu.Type = item.Type;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
