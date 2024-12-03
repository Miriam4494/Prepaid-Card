using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Service.Services
{
    public class StoreService: IService<StoreEntity>
    {
        readonly IRepository<StoreEntity> _iRepository;
        public StoreService(IRepository<StoreEntity> iRepository)
        {
            _iRepository = iRepository;
        }
        public List<StoreEntity> Get()
        {
            return _iRepository.Get();
        }
        public StoreEntity GetById(int id)
        {
            return _iRepository.GetById(id);
        }
        public bool Add(StoreEntity order)
        {
            return _iRepository.Add(order);
        }
        public bool Update(int id, StoreEntity order)
        {
            return _iRepository.Update(id, order);
        }
        public bool Delete(int id)
        {
            return _iRepository.Delete(id);
        }
    }
}
