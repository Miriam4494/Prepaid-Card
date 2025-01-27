using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Core.DTOs
{
    public class PurchaseCenterDTO
    {
        public int PurchaseCenterId { get; set; }//מזהה מוקד רכישה
        public string NamePurchasePoint { get; set; }//שם מוקד רכישה
        public string Address { get; set; }//כתובת
        public string City { get; set; }//עיר
        public string? Phone { get; set; }//טלפון
        public string Email { get; set; }//מייל
        public int Quantity { get; set; }//כמות המלאי
    }
}
