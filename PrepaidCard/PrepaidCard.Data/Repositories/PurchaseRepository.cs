using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Data.Repositories
{
    public class PurchaseRepository:IRepository<PurchaseEntity>
    {
        readonly DataContext _dataContext;
        public PurchaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<PurchaseEntity> Get()
        {

            return _dataContext.purchases;
        }
        //שליפת רכישה לפי מזהה רכישה
        public PurchaseEntity GetById(int id)
        {
            if (_dataContext.purchases == null || (_dataContext.purchases.FindIndex(p => p.PurchaseId == id)) == -1)
                return null;
            return _dataContext.purchases.Find(purchase => purchase.PurchaseId == id);
        }
        #region פונקציות מיוחדות
        //שליפת רכישה לפי מזהה כרטיס
        //public PurchaseEntity GetPurchaseByCard(int id)
        //{
        //    if (_dataContext.purchases == null || (_dataContext.purchases.FindIndex(b => b.CardId == id)) == -1)
        //        return null;
        //    return _dataContext.purchases.Find(purchase => purchase.CardId == id);
        //}
        //שליפת רכישה לפי מזהה מוקד
        public PurchaseEntity GetPurchaseByPurchaseCenter(int id)
        {
            if (_dataContext.purchases == null || (_dataContext.purchases.FindIndex(b => b.PurchaseCenterId == id)) == -1)
                return null;
            return _dataContext.purchases.Find(purchase => purchase.PurchaseCenterId == id);
        }
        #endregion

        //הוספת רכישה
        public bool Add(PurchaseEntity purchase)
        {
            if (_dataContext.purchases == null)
                _dataContext.purchases = new List<PurchaseEntity>();
            if (_dataContext.purchases.Find(p => p.PurchaseId == purchase.PurchaseId) != null) return false;

            _dataContext.purchases.Add(purchase);
            return _dataContext.Save(_dataContext.purchases, "Data/Purchases.csv");

        }
        //עדכון רכישה
        public bool Update(int id, PurchaseEntity purchase)
        {
            if (_dataContext.purchases == null || (_dataContext.purchases.FindIndex(b => b.PurchaseId == id) == -1))
                return false;
            int index = _dataContext.purchases.FindIndex(purchase => purchase.PurchaseId == id);
            _dataContext.purchases[index].CardId = purchase.CardId;
            _dataContext.purchases[index].Sum = purchase.Sum;
            _dataContext.purchases[index].CustomerId = purchase.CustomerId;
            _dataContext.purchases[index].PurchaseCenterId = purchase.PurchaseCenterId;
            _dataContext.purchases[index].DateOfPurchase = purchase.DateOfPurchase;
            return _dataContext.Save(_dataContext.purchases, "Data/Purchases.csv");

        }
        //מחיקת רכישה
        public bool Delete(int id)
        {
            if (_dataContext.purchases == null || (_dataContext.purchases.FindIndex(b => b.PurchaseId == id)) == -1)
                return false;
            _dataContext.purchases.Remove(_dataContext.purchases.Find(p => p.PurchaseId == id));
            return _dataContext.Save(_dataContext.purchases, "Data/Purchases.csv");

        }
    }
}
