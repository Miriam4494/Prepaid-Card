using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Service.Services
{
    public class StoreService: StoreIService
    {
        readonly IRepository<StoreEntity> _iRepository;
        public StoreService(IRepository<StoreEntity> iRepository)
        {
            _iRepository = iRepository;
        }
        public List<StoreEntity> GetStores()
        {
            return _iRepository.Get();
        }
        public StoreEntity GetStoreById(int id)
        {
            return _iRepository.GetById(id);
        }
        public StoreEntity AddStore(StoreEntity order)
        {
            return _iRepository.Add(order);
        }
        public StoreEntity UpdateStore(int id, StoreEntity order)
        {
            return _iRepository.Update(id, order);
        }
        public bool DeleteStore(int id)
        {
            return _iRepository.Delete(id);
        }
    }
}
