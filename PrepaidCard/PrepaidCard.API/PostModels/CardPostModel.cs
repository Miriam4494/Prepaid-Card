using PrepaidCard.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrepaidCard.API.PostModels
{
    public class CardPostModel
    {
        public DateTime DateOfPurchase { get; set; } //תאריך רכישה
        public DateTime CardValidity { get; set; } //תוקף כרטיס
        public string PurchaseCenter { get; set; } //מוקד רכישה
        public Double Sum { get; set; }// סכום
        public string? ColorCard { get; set; }// צבע כרטיס
        public int CustomerId { get; set; }//מזהה לקוח
    }
}
