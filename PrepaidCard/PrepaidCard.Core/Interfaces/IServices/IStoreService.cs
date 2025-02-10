using PrepaidCard.Core.DTOs;
using PrepaidCard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Core.Interfaces.IServices
{
    public interface IStoreService
    {
        public Task<IEnumerable<StoreDTO>> GetallAsync();
        public StoreDTO GetStoreById(int id);
        public StoreDTO AddStore(StoreDTO store);
        public StoreDTO UpdateStore(int id, StoreDTO store);
        public bool DeleteStore(int id);
    }
}
