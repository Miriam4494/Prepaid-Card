using PrepaidCard.Core.DTOs;
using PrepaidCard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Core.Interfaces.IServices
{
    public interface IPurchaseCenterService
    {
        public IEnumerable<PurchaseCenterDTO> GetPurchaseCenters();
        public PurchaseCenterDTO GetPurchaseCenterById(int id);
        public PurchaseCenterDTO AddPurchaseCenter(PurchaseCenterDTO purchaseCenterEntity);
        public PurchaseCenterDTO UpdatePurchaseCenter(int id, PurchaseCenterDTO purchaseCenterEntity);
        public bool DeletePurchaseCenter(int id);
    }
}
