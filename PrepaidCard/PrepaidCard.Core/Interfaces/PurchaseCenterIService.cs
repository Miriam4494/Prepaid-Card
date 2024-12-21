using PrepaidCard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Core.Interfaces
{
    public interface PurchaseCenterIService
    {
        public List<PurchaseCenterEntity> GetPurchaseCenters();
        public PurchaseCenterEntity GetPurchaseCenterById(int id);
        public PurchaseCenterEntity AddPurchaseCenter(PurchaseCenterEntity purchaseCenterEntity);
        public PurchaseCenterEntity UpdatePurchaseCenter(int id, PurchaseCenterEntity purchaseCenterEntity);
        public bool DeletePurchaseCenter(int id);
    }
}
