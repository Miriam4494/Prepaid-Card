using Microsoft.EntityFrameworkCore;
using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Data.Repositories
{
    public class PurchaseCenterRepository:Repository<PurchaseCenterEntity>,IPurchaseCenterRepository
    {


        public PurchaseCenterRepository(DataContext dataContext) : base(dataContext)
        {

        }
        public List<PurchaseCenterEntity> GetFull()
        {
            return _dbSet.Include(p => p.Purchase).ToList();
        }


        //readonly DataContext _dataContext;
        //public PurchaseCenterRepository(DataContext dataContext)
        //{
        //    _dataContext = dataContext;
        //}
        //public List<PurchaseCenterEntity> Get()
        //{

        //    return _dataContext.purchaseCenters.ToList();
        //}
        //public PurchaseCenterEntity GetById(int id)
        //{
        //    if (_dataContext.purchaseCenters == null || (_dataContext.purchaseCenters.ToList().FindIndex(p => p.PurchaseCenterId == id) == -1))
        //        return null;
        //    return _dataContext.purchaseCenters.Find( id);
        //}
        //#region especial function
        ////שליפת מוקד לפי עיר
        ////public PurchaseCenterEntity GetByCity(string city)
        ////{
        ////    if (_dataContext.purchaseCenters == null || (_dataContext.purchaseCenters.FindIndex(p => p.City == city) == -1))
        ////        return null;
        ////    return _dataContext.purchaseCenters.Find(p => p.City == city);
        ////}
        //#endregion

        //public PurchaseCenterEntity Add(PurchaseCenterEntity purchaseCenter)
        //{


        //    if (_dataContext.purchaseCenters.Find( purchaseCenter.PurchaseCenterId) != null) return null;

        //    _dataContext.purchaseCenters.Add(purchaseCenter);
        //    try
        //    {
        //        _dataContext.SaveChanges();
        //        return purchaseCenter;

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }

        //}
        //public PurchaseCenterEntity Update(int id, PurchaseCenterEntity purchaseCenter)
        //{
        //    if (_dataContext.purchaseCenters == null || purchaseCenter== null)
        //        return null;

        //    PurchaseCenterEntity pc = _dataContext.purchaseCenters.Find(id);
        //    if (pc == null)
        //        return null;


        //    pc.City = purchaseCenter.City!=null?purchaseCenter.City:pc.City;
        //    pc.Email = purchaseCenter.Email!=null?purchaseCenter.Email:pc.Email;
        //    pc.Quantity = purchaseCenter.Quantity!=null?purchaseCenter.Quantity:pc.Quantity;
        //    pc.Address = purchaseCenter.Address != null ? purchaseCenter.Address : pc.Address;
        //    pc.Phone = purchaseCenter.Phone!=null?purchaseCenter.Phone:pc.Phone;
        //    pc.NamePurchasePoint = purchaseCenter.NamePurchasePoint != null ? purchaseCenter.NamePurchasePoint : pc.NamePurchasePoint;
        //    try
        //    {
        //        _dataContext.SaveChanges();
        //        return purchaseCenter;

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }

        //}
        //public bool Delete(int id)
        //{
        //    if (_dataContext.purchaseCenters == null || (_dataContext.purchaseCenters.Find( id)==null))
        //        return false;
        //    _dataContext.purchaseCenters.Remove(_dataContext.purchaseCenters.Find( id));
        //    try
        //    {
        //        _dataContext.SaveChanges();
        //        return true;

        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //}
    }
}
