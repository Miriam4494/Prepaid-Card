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
    [Table("Cards")]
    public class CardEntity
    {
        [Key]
        public int CardId { get; set; }//מזהה כרטיס
        public DateTime DateOfPurchase { get; set; } //תאריך רכישה
        public DateTime CardValidity { get; set; } //תוקף כרטיס
        public string PurchaseCenter { get; set; } //מוקד רכישה
        public Double Sum { get; set; }// סכום
        public string? ColorCard { get; set; }// צבע כרטיס
        public int CustomerId { get; set; }//מזהה לקוח
        [ForeignKey(nameof(CustomerId))]
        public CustomerEntity Customer { get; set; }
        public List<PurchaseEntity> Purchase { get; set; }

    }
}
