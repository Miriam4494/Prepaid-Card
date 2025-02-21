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
    [Table("Customers")]

    public class CustomerEntity
    {
        [Key]
       // [JsonIgnore]
        public int CustomerId { get; set; }//קוד לקוח
        public string FirstName { get; set; }//שם פרטי
        public string LastName { get; set; }//שם משפחה
        public string TZ { get; set; }//תעודת זהות
        [StringLength(10, MinimumLength = 8)]
        public string Phone { get; set; }//טלפון
        public string? Adress { get; set; }//כתובת
        public string Email { get; set; }//מייל
        public DateTime DateOfBirth { get; set; } //תאריך לידה
        public DateTime DateOfJoin { get; set; }//תאריך הצטרפות
        public List<CardEntity> Cards { get; set; }

    }
}
