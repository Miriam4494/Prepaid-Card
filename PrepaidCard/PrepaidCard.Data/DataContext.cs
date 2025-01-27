using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using PrepaidCard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Data
{
    public class DataContext:DbContext
    {
        public DbSet<CardEntity> Cards { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<PurchaseCenterEntity> PurchaseCenters { get; set; }
        public DbSet<PurchaseEntity> Purchases { get; set; }
        public DbSet<StoreEntity> Stores { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-1VUANBN;Database=prepaid_card_db;Integrated Security=True;TrustServerCertificate=True;Trusted_Connection=True");
        }
        


    }
}
