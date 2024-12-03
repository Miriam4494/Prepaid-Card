using CsvHelper;
using CsvHelper.Configuration;
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
    public class DataContext
    {
        public List<CardEntity> cards;
        public List<CustomerEntity> customers;
        public List<PurchaseCenterEntity> purchaseCenters;
        public List<PurchaseEntity> purchases;
        public List<StoreEntity> stores;
        public DataContext()
        {
            cards = Load<CardEntity>("Data/Cards.csv");
            customers = Load<CustomerEntity>("Data/Customers.csv");
            purchaseCenters = Load<PurchaseCenterEntity>("Data/PurchaseCenters.csv");
            purchases = Load<PurchaseEntity>("Data/Purchases.csv");
            stores = Load<StoreEntity>("Data/Stores.csv");
        }

        public List<T> Load<T>(string fileName)
        {
            try
            {
                // נתיב בסיס חדש
                string basePath = @"C:\מירי\תכנות\שנה ב\Net Core\Project\PrepaidCard\PrepaidCard.Data";

                // יצירת נתיב מלא
                string path = Path.Combine(basePath, fileName);

                // בדיקה אם הקובץ קיים
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException($"The file {fileName} was not found in {basePath}");
                }

                // קריאת הקובץ וטעינת הנתונים
                using var reader = new StreamReader(path);
                using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                });

                var records = csv.GetRecords<T>().ToList();
                return records;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
                return null;
            }
        }


        public bool Save<T>(List<T> data, string fileName)
        {
            try
            {
                // נתיב בסיס חדש
                string basePath = @"C:\מירי\תכנות\שנה ב\Net Core\Project\PrepaidCard\PrepaidCard.Data";

                // יצירת נתיב מלא
                string path = Path.Combine(basePath, fileName);

                // בדיקה אם התיקייה קיימת, ואם לא - יצירה שלה
                if (!Directory.Exists(basePath))
                {
                    Directory.CreateDirectory(basePath);
                }

                // כתיבת הנתונים לקובץ
                using var writer = new StreamWriter(path);
                using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true
                });

                csv.WriteRecords(data);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
                return false;
            }
        }
        
              




    }
}
