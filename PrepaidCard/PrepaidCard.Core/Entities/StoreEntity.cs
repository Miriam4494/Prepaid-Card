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
    [Table("Store")]
    public class StoreEntity
    {
        [Key]
        //[JsonIgnore]
        public int StoreId { get; set; }//מזהה חנות
        public string StoreName { get; set; }//שם
        public string Address { get; set; }//כתובת
        public string City { get; set; }//עיר
        public string Phone { get; set; }//טלפון
        public string Email { get; set; }//מייל
        public string Manager { get; set; }//מנהל
        public string SiteStore { get; set; }//אתר חנות
        //public StoreEntity() { }

        //public StoreEntity(int storeId, string name, string address, string city, string phone, string email, string manager, string siteStore)
        //{
        //    StoreId = storeId;
        //    StoreName = name;
        //    Address = address;
        //    City = city;
        //    Phone = phone;
        //    Email = email;
        //    Manager = manager;
        //    SiteStore = siteStore;
        //}
    }
}
