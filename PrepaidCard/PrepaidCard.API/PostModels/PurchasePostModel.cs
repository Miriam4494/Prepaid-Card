using PrepaidCard.Core.Entities;

namespace PrepaidCard.API.PostModels
{
    public class PurchasePostModel
    {
        public int CardId { get; set; }//מזהה כרטיס
        public int PurchaseCenterId { get; set; }//מזהה מוקד רכישה
        public DateTime DateOfPurchase { get; set; }//תאריך
        public Double Sum { get; set; }//סכום
        public TypesOfPaymentMethods PaymentMethod { get; set; }//אופן התשלום
    }
}
