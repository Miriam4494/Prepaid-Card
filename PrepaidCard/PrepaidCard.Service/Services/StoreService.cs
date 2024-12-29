using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces.IRepositories;
using PrepaidCard.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Service.Services
{
    public class StoreService: IStoreService
    {
        readonly IRepositoryManager _repositoryManager;

        public StoreService(IRepositoryManager iRepository)
        {
            _repositoryManager = iRepository;
        }
        public List<StoreEntity> GetStores()
        {
            //return _repositoryManager._storeRepository.Get();
            return _repositoryManager._storeRepository.GetFull();
        }
        public StoreEntity GetStoreById(int id)
        {
            return _repositoryManager._storeRepository.GetById(id);
        }
        public StoreEntity AddStore(StoreEntity order)
        {

            StoreEntity s = _repositoryManager._storeRepository.Add(order);
            if (s != null)
                _repositoryManager.save();
            return s;
            
        }
        public StoreEntity UpdateStore(int id, StoreEntity order)
        {
            StoreEntity s = _repositoryManager._storeRepository.Update(id, order);
            if (s != null)
                _repositoryManager.save();
            return s;
        }
        public bool DeleteStore(int id)
        {
            bool succeed = _repositoryManager._storeRepository.Delete(id);
            if (succeed)
                _repositoryManager.save();
            return succeed;
        }
    }
}
