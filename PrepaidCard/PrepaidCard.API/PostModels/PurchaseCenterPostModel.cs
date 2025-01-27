using PrepaidCard.Core.Entities;

namespace PrepaidCard.API.PostModels
{
    public class PurchaseCenterPostModel
    {
        public string NamePurchasePoint { get; set; }//שם מוקד רכישה
        public string Address { get; set; }//כתובת
        public string City { get; set; }//עיר
        public string? Phone { get; set; }//טלפון
        public string Email { get; set; }//מייל
        public int Quantity { get; set; }//כמות המלאי
        public List<PurchaseEntity> Purchase { get; set; }

    }
}
