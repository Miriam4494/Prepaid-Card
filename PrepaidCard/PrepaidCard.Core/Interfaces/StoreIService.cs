using PrepaidCard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Core.Interfaces
{
    public interface StoreIService
    {
        public List<StoreEntity> GetStores();
        public StoreEntity GetStoreById(int id);
        public StoreEntity AddStore(StoreEntity store);
        public StoreEntity UpdateStore(int id, StoreEntity store);
        public bool DeleteStore(int id);
    }
}
