﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PrepaidCard.Core.Entities
{
    [Flags]
    public enum TypesOfPaymentMethods { CASH, CREDITCARD, CHECK }
    [Table("Purchase")]
    public class PurchaseEntity
    {
        [Key]
        //[JsonIgnore]
        public int PurchaseId { get; set; }//מזהה טעינה
        public int CardId { get; set; }//מזהה כרטיס
        public int PurchaseCenterId { get; set; }//מזהה מוקד רכישה
        public DateTime DateOfPurchase { get; set; }//תאריך
        public Double Sum { get; set; }//סכום
        public TypesOfPaymentMethods PaymentMethod { get; set; }//אופן התשלום

    }
}
