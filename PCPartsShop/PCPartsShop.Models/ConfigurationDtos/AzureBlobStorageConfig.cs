using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Domain.ConfigurationDtos
{
    public class AzureBlobStorageConfig
    {
        public string StorageAccountName { get; set; }
        public string StorageAccountKey { get; set; }
  }
}

