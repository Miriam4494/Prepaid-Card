using PrepaidCard.Core.DTOs;
using PrepaidCard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Core.Interfaces.IServices
{
    public interface IPurchaseService
    {
        public Task<IEnumerable<PurchaseDTO>> GetallAsync();
        public PurchaseDTO GetPurchaseById(int id);
        public PurchaseDTO AddPurchase(PurchaseDTO purchase);
        public PurchaseDTO UpdatePurchase(int id, PurchaseDTO purchase);
        public bool DeletePurchase(int id);
    }
}
