using AutoMapper;
using PrepaidCard.Core.DTOs;
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
        private readonly IMapper _mapper;


        public StoreService(IRepositoryManager iRepository,IMapper mapper)
        {
            _repositoryManager = iRepository;
            _mapper = mapper;
        }
        public IEnumerable<StoreDTO> GetStores()
        {
            var stores = _repositoryManager._storeRepository.GetFull();
            return _mapper.Map<IEnumerable<StoreDTO>>(stores);
        }
        public StoreDTO GetStoreById(int id)
        {
            var store = _repositoryManager._storeRepository.GetById(id);
            return _mapper.Map<StoreDTO>(store);

        }

        public StoreDTO AddStore(StoreDTO card)
        {
            var s = _mapper.Map<StoreEntity>(card);
            s = _repositoryManager._storeRepository.Add(s);
            if (s != null)
                _repositoryManager.save();
            return _mapper.Map<StoreDTO>(s);
        }
        public StoreDTO UpdateStore(int id, StoreDTO card)
        {

            var s = _mapper.Map<StoreEntity>(card);

            s = _repositoryManager._storeRepository.Update(id, s);
            if (s != null)
                _repositoryManager.save();
            return _mapper.Map<StoreDTO>(s);

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
