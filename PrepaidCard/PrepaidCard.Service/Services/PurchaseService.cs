using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Service.Services
{
    public class PurchaseService:IService<PurchaseEntity>
    {
        readonly IRepository<PurchaseEntity> _iRepository;
        public PurchaseService(IRepository<PurchaseEntity> iRepository)
        {
            _iRepository = iRepository;
        }
        public List<PurchaseEntity> Get()
        {
            return _iRepository.Get();
        }
        public PurchaseEntity GetById(int id)
        {
            return _iRepository.GetById(id);
        }
        public bool Add(PurchaseEntity order)
        {
            return _iRepository.Add(order);
        }
        public bool Update(int id, PurchaseEntity order)
        {
            return _iRepository.Update(id, order);
        }
        public bool Delete(int id)
        {
            return _iRepository.Delete(id);
        }
    }
}
