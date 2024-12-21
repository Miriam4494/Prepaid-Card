using PrepaidCard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Core.Interfaces
{
    public interface PurchaseIService
    {
        public List<PurchaseEntity> GetPurchases();
        public PurchaseEntity GetPurchaseById(int id);
        public PurchaseEntity AddPurchase(PurchaseEntity purchase);
        public PurchaseEntity UpdatePurchase(int id, PurchaseEntity purchase);
        public bool DeletePurchase(int id);
    }
}
