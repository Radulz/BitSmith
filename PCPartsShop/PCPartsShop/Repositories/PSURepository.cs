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

        public void Delete(int id)
        {
            foreach(PSU p in PSUs)
            {
                if(p.ID == id)
                {
                    PSUs.Remove(p);
                    return;
                }
            }
        }

        public List<PSU> GetAll()
        {
            return PSUs;
        }

        public PSU GetItem(int id)
        {
            foreach (PSU p in PSUs)
            {
                if (p.ID == id)
                {
                    return p;
                }
            }
            return null;
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
