using PrepaidCard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Core.DTOs
{
    public class PurchaseDTO
    {
        public int PurchaseId { get; set; }//מזהה טעינה
        public int CardId { get; set; }//מזהה כרטיס
        public int PurchaseCenterId { get; set; }//מזהה מוקד רכישה
        public DateTime DateOfPurchase { get; set; }//תאריך
        public Double Sum { get; set; }//סכום
        public TypesOfPaymentMethods PaymentMethod { get; set; }//אופן התשלום
    }
}
