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
    [Table("PurchaseCenters")]

    public class PurchaseCenterEntity
    {
        [Key]
        //[JsonIgnore]
        public int PurchaseCenterId { get; set; }//מזהה מוקד רכישה
        public string NamePurchasePoint { get; set; }//שם מוקד רכישה
        public string Address { get; set; }//כתובת
        public string City { get; set; }//עיר
        public string? Phone { get; set; }//טלפון
        public string Email { get; set; }//מייל
        public int Quantity { get; set; }//כמות המלאי
        public List<PurchaseEntity> Purchase { get; set; }
        
    }
}

