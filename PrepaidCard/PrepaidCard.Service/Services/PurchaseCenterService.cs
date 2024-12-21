using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Service.Services
{
    public class PurchaseCenterService : PurchaseCenterIService
    {
            readonly IRepository<PurchaseCenterEntity> _iRepository;
            public PurchaseCenterService(IRepository<PurchaseCenterEntity> iRepository)
            {
                _iRepository = iRepository;
            }
            public List<PurchaseCenterEntity> GetPurchaseCenters()
            {
                return _iRepository.Get();
            }
            public PurchaseCenterEntity GetPurchaseCenterById(int id)
            {
                return _iRepository.GetById(id);
            }
            public PurchaseCenterEntity AddPurchaseCenter(PurchaseCenterEntity order)
            {
                return _iRepository.Add(order);
            }
            public PurchaseCenterEntity UpdatePurchaseCenter(int id, PurchaseCenterEntity order)
            {
                return _iRepository.Update(id, order);
            }
            public bool DeletePurchaseCenter(int id)
            {
                return _iRepository.Delete(id);
            }
    }
}

