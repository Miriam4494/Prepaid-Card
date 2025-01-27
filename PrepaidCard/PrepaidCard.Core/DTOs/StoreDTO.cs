using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Core.DTOs
{
    public class StoreDTO
    {
        public int StoreId { get; set; }//מזהה חנות
        public string StoreName { get; set; }//שם
        public string? Address { get; set; }//כתובת
        public string City { get; set; }//עיר
        public string Phone { get; set; }//טלפון
        public string Email { get; set; }//מייל
        public string Manager { get; set; }//מנהל
        public string SiteStore { get; set; }//אתר חנות

    }
}
