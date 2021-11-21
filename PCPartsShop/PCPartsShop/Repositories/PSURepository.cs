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
        private readonly List<PSU> _PSUs;
        public PSURepository()
        {
            _PSUs = new List<PSU>();
        }
        public void Add(PSU item)
        {
            _PSUs.Add(item);
        }

        public void Delete(Guid id)
        {
            var psu = _PSUs.FirstOrDefault(item => item.ComponentId == id);
            if (psu != null)
            {
                _PSUs.Remove(psu);
            }
        }

        public IEnumerable<PSU> GetAll()
        {
            return _PSUs;
        }

        public PSU GetItem(Guid id)
        {
            var psu = _PSUs.FirstOrDefault(item => item.ComponentId == id);

            if (psu != null)
            {
                return psu;
            }

            return null;
        }

        public void Update(PSU item)
        {
            var psuindex = _PSUs.FindIndex(x => x.ComponentId == item.ComponentId);
            if (psuindex != -1)
            {
                _PSUs[psuindex] = item;
            }
        }
    }
}
