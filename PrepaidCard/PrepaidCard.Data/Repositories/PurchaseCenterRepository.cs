using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Data.Repositories
{
    public class PurchaseCenterRepository:IRepository<PurchaseCenterEntity>
    {
        readonly DataContext _dataContext;
        public PurchaseCenterRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        //שליפת רשימת מוקדים
        public List<PurchaseCenterEntity> Get()
        {

            return _dataContext.purchaseCenters;
        }
        //שליפת מוקד לפי מזהה
        public PurchaseCenterEntity GetById(int id)
        {
            if (_dataContext.purchaseCenters == null || (_dataContext.purchaseCenters.FindIndex(p => p.PurchaseCenterId == id) == -1))
                return null;
            return _dataContext.purchaseCenters.Find(p => p.PurchaseCenterId == id);
        }
        #region פונקציות מיוחדות
        //שליפת מוקד לפי עיר
        //public PurchaseCenterEntity GetByCity(string city)
        //{
        //    if (_dataContext.purchaseCenters == null || (_dataContext.purchaseCenters.FindIndex(p => p.City == city) == -1))
        //        return null;
        //    return _dataContext.purchaseCenters.Find(p => p.City == city);
        //}
        #endregion

        //הוספת מוקד
        public bool Add(PurchaseCenterEntity purchaseCenter)
        {

            if (_dataContext.purchaseCenters == null)
                _dataContext.purchaseCenters = new List<PurchaseCenterEntity>();
            if (_dataContext.purchaseCenters.Find(p => p.PurchaseCenterId == purchaseCenter.PurchaseCenterId) != null) return false;

            _dataContext.purchaseCenters.Add(purchaseCenter);
            return _dataContext.Save(_dataContext.purchaseCenters, "Data/PurchaseCenters.csv");

        }
        //עדכון מוקד
        public bool Update(int id, PurchaseCenterEntity purchaseCenter)
        {
            if (_dataContext.purchaseCenters == null || (_dataContext.purchaseCenters.FindIndex(p => p.PurchaseCenterId == id) == -1))
                return false;
            int index = _dataContext.purchaseCenters.FindIndex(p => p.PurchaseCenterId == id);
            _dataContext.purchaseCenters[index].City = purchaseCenter.City;
            _dataContext.purchaseCenters[index].Email = purchaseCenter.Email;
            _dataContext.purchaseCenters[index].Quantity = purchaseCenter.Quantity;
            _dataContext.purchaseCenters[index].Address = purchaseCenter.Address;
            _dataContext.purchaseCenters[index].Phone = purchaseCenter.Phone;
            _dataContext.purchaseCenters[index].NamePurchasePoint = purchaseCenter.NamePurchasePoint;
            return _dataContext.Save(_dataContext.purchaseCenters, "Data/PurchaseCenters.csv");

        }
        //מחיקת מוקד
        public bool Delete(int id)
        {
            if (_dataContext.purchaseCenters == null || (_dataContext.purchaseCenters.FindIndex(p => p.PurchaseCenterId == id) == -1))
                return false;
            _dataContext.purchaseCenters.Remove(_dataContext.purchaseCenters.Find(p => p.PurchaseCenterId == id));
            return _dataContext.Save(_dataContext.purchaseCenters, "Data/PurchaseCenters.csv");

        }
    }
}
