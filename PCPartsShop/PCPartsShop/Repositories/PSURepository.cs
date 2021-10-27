using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;

namespace PCPartsShop.Repositories
{
    public class PSURepository : IRepository<PSU>
    {
        public List<PSU> PSUs = new List<PSU>();
        public PSURepository()
        {

        }
        public void Add(PSU item)
        {
            PSUs.Add(item);
        }

        public void Delete(Guid id)
        {
            var psu = PSUs.First(item => item.UniqueId == id);
            if (psu != null)
            {
                PSUs.Remove(psu);
            }
        }

        public List<PSU> GetAll()
        {
            return PSUs;
        }

        public PSU GetItem(Guid id)
        {
            var psu = PSUs.First(item => item.UniqueId == id);

            if (psu != null)
            {
                return psu;
            }

            return null;
        }

        public void Update(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
