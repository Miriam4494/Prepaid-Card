using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PrepaidCard.Core.Entities
{
    [Table("Card")]
    public class CardEntity
    {
        [Key]
        //[JsonIgnore]
        public int CardId { get; set; }//מזהה כרטיס
        public DateTime DateOfPurchase { get; set; } //תאריך רכישה
        public DateTime CardValidity { get; set; } //תוקף כרטיס
        public string PurchaseCenter { get; set; } //מוקד רכישה
        public Double Sum { get; set; }// סכום
        public string ColorCard { get; set; }// צבע כרטיס
        public int CustomerId { get; set; }//מזהה לקוח
        [ForeignKey(nameof(CustomerId))]
        public CustomerEntity Customer { get; set; }
        public List<PurchaseEntity> Purchase { get; set; }

        //public CardEntity()
        //{

        //}

        //public CardEntity(int cardId, DateTime dateOfPurchase, DateTime cardValidity, string purchaseCenter, double sum, int customerId, string colorCard)
        //{
        //    CardId = cardId;
        //    DateOfPurchase = dateOfPurchase;
        //    CardValidity = cardValidity;
        //    PurchaseCenter = purchaseCenter;
        //    Sum = sum;
        //    CustomerId = customerId;
        //    ColorCard = colorCard;
        //}

    }
}
