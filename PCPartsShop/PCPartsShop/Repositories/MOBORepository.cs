using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;

namespace PCPartsShop.Repositories
{
    public class MOBORepository : IComponentRepository<MOBO>
    {
        private readonly PCPartsShopContext _dbContext;
        public MOBORepository(PCPartsShopContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(MOBO item)
        {
            _dbContext.MOBOs.Add(item);
            _dbContext.SaveChanges();
        }

        public bool Delete(Guid id)
        {
            var mobo = _dbContext.MOBOs.FirstOrDefault(item => item.ComponentId == id);
            if (mobo != null)
            {
                _dbContext.MOBOs.Remove(mobo);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<MOBO> GetAll()
        {
            return _dbContext.MOBOs;
        }

        public MOBO GetItem(Guid id)
        {
            var mobo = _dbContext.MOBOs.FirstOrDefault(item => item.ComponentId == id);

            if (mobo != null)
            {
                return mobo;
            }

            return null;
        }

        public bool Update(MOBO item)
        {
            var mobo = _dbContext.MOBOs.FirstOrDefault(x => x.ComponentId == item.ComponentId);
            if (mobo != null)
            {
                mobo.Make = item.Make;
                mobo.Model = item.Model;
                mobo.Price = item.Price;
                mobo.Image = item.Image;
                mobo.Chipset = item.Chipset;
                mobo.Format = item.Format;
                mobo.MemoryFreqInf = item.MemoryFreqInf;
                mobo.MemoryFreqSup = item.MemoryFreqSup;
                mobo.MemoryType = item.MemoryType;
                mobo.Socket = item.Socket;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
