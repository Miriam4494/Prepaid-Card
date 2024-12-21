using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Service.Services
{
    public class PurchaseService:PurchaseIService
    {
        readonly IRepository<PurchaseEntity> _iRepository;
        public PurchaseService(IRepository<PurchaseEntity> iRepository)
        {
            _iRepository = iRepository;
        }
        public List<PurchaseEntity> GetPurchases()
        {
            return _iRepository.Get();
        }
        public PurchaseEntity GetPurchaseById(int id)
        {
            return _iRepository.GetById(id);
        }
        public PurchaseEntity AddPurchase(PurchaseEntity order)
        {
            return _iRepository.Add(order);
        }
        public PurchaseEntity UpdatePurchase(int id, PurchaseEntity order)
        {
            return _iRepository.Update(id, order);
        }
        public bool DeletePurchase(int id)
        {
            return _iRepository.Delete(id);
        }
    }
}
