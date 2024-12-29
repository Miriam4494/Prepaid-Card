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
    public class PurchaseCenterService : IPurchaseCenterService
    {
        readonly IRepositoryManager _repositoryManager;

        public PurchaseCenterService(IRepositoryManager iRepository)
        {
            _repositoryManager = iRepository;
        }
        public List<PurchaseCenterEntity> GetPurchaseCenters()
            {
                //return _repositoryManager._purchaseCenterRepository.Get();
                return _repositoryManager._purchaseCenterRepository.GetFull();
            }
            public PurchaseCenterEntity GetPurchaseCenterById(int id)
            {
                return _repositoryManager._purchaseCenterRepository.GetById(id);
            }
            public PurchaseCenterEntity AddPurchaseCenter(PurchaseCenterEntity order)
            {
                PurchaseCenterEntity p = _repositoryManager._purchaseCenterRepository.Add(order);
                if (p != null)
                    _repositoryManager.save();
                return p;
            }
            public PurchaseCenterEntity UpdatePurchaseCenter(int id, PurchaseCenterEntity order)
            {
                PurchaseCenterEntity p = _repositoryManager._purchaseCenterRepository.Update(id, order);
                if (p != null)
                     _repositoryManager.save();
                return p;
            }
            public bool DeletePurchaseCenter(int id)
            {
                bool succeed = _repositoryManager._purchaseCenterRepository.Delete(id);
                if (succeed)
                    _repositoryManager.save();
                return succeed;
            }
    }
}

