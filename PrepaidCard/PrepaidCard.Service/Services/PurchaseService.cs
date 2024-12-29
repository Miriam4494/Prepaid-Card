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
    public class PurchaseService:IPurchaseService
    {
        readonly IRepositoryManager _repositoryManager;

        public PurchaseService(IRepositoryManager iRepository)
        {
            _repositoryManager = iRepository;
        }
        public List<PurchaseEntity> GetPurchases()
        {
            //return _repositoryManager._purchaseRepository.Get();
            return _repositoryManager._purchaseRepository.GetFull();
        }
        public PurchaseEntity GetPurchaseById(int id)
        {
            return _repositoryManager._purchaseRepository.GetById(id);
        }
        public PurchaseEntity AddPurchase(PurchaseEntity order)
        {

            PurchaseEntity p = _repositoryManager._purchaseRepository.Add(order);
            if (p != null)
                _repositoryManager.save();
            return p;
            
        }
        public PurchaseEntity UpdatePurchase(int id, PurchaseEntity order)
        {
            PurchaseEntity p = _repositoryManager._purchaseRepository.Update(id, order);
            if (p != null)
                _repositoryManager.save();
            return p;
        }
        public bool DeletePurchase(int id)
        {
            bool succeed = _repositoryManager._purchaseRepository.Delete(id);
            if (succeed)
                _repositoryManager.save();
            return succeed;
        }
    }
}
