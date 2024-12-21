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

            return _dataContext.purchases.ToList();
        }
        public PurchaseEntity GetById(int id)
        {
            if (_dataContext.purchases == null || (_dataContext.purchases.ToList().FindIndex(p => p.PurchaseId == id)) == -1)
                return null;
            return _dataContext.purchases.ToList().Find(purchase => purchase.PurchaseId == id);
        }
        #region especial function
        //שליפת רכישה לפי מזהה כרטיס
        //public PurchaseEntity GetPurchaseByCard(int id)
        //{
        //    if (_dataContext.purchases == null || (_dataContext.purchases.FindIndex(b => b.CardId == id)) == -1)
        //        return null;
        //    return _dataContext.purchases.Find(purchase => purchase.CardId == id);
        //}
        //שליפת רכישה לפי מזהה מוקד
        //public PurchaseEntity GetPurchaseByPurchaseCenter(int id)
        //{
        //    if (_dataContext.purchases == null || (_dataContext.purchases.FindIndex(b => b.PurchaseCenterId == id)) == -1)
        //        return null;
        //    return _dataContext.purchases.Find(purchase => purchase.PurchaseCenterId == id);
        //}
        #endregion

        public PurchaseEntity Add(PurchaseEntity purchase)
        {
           
            if (_dataContext.purchases.Find( purchase.PurchaseId) != null) return null;

            _dataContext.purchases.Add(purchase);
            try
            {
                _dataContext.SaveChanges();
                return purchase;

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public PurchaseEntity Update(int id, PurchaseEntity purchase)
        {
            if (_dataContext.purchases == null ||  purchase== null)
                return null;
            PurchaseEntity p = _dataContext.purchases.Find(id);
            if (p == null)
                return null;
            p.CardId = purchase.CardId!=null?purchase.CardId:p.CardId;
            p.Sum = purchase.Sum!=null?purchase.Sum:p.Sum;
            p.CustomerId = purchase.CustomerId!=null?purchase.CustomerId:p.CustomerId;
            p.PurchaseCenterId = purchase.PurchaseCenterId!=null?purchase.PurchaseCenterId:p.PurchaseCenterId;
            p.DateOfPurchase = purchase.DateOfPurchase!=null?purchase.DateOfPurchase:p.DateOfPurchase;
            try
            {
                _dataContext.SaveChanges();
                return purchase;

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public bool Delete(int id)
        {
            if (_dataContext.purchases == null || (_dataContext.purchases.ToList().FindIndex(b => b.PurchaseId == id)) == -1)
                return false;
            _dataContext.purchases.Remove(_dataContext.purchases.Find(id));
            try
            {
                _dataContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
