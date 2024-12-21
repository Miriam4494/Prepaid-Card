using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Data.Repositories
{
    public class StoreRepository:IRepository<StoreEntity>
    {
        readonly DataContext _dataContext;
        public StoreRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<StoreEntity> Get()
        {

            return _dataContext.stores.ToList();
        }
       
        public StoreEntity GetById(int id)
        {
            if (_dataContext.stores == null || (_dataContext.stores.Find(id) == null))
                return null;
            return _dataContext.stores.Find(id);
        }
        #region especial function
        //שליפת חנות לפי שם חנות
        //public StoreEntity GetStoreByName(string name)
        //{
        //    if (DataManager.dataContexts.store == null || (DataManager.dataContexts.store.Find(s => s.StoreName == name) == null))
        //        return null;
        //    return DataManager.dataContexts.store.Find(store => store.StoreName == name);
        //}
        #endregion

        public StoreEntity Add(StoreEntity storee)
        {
            if (_dataContext.stores.Find(storee.StoreId) != null) return null;
            _dataContext.stores.Add(storee);
            try
            {
                _dataContext.SaveChanges();
                return storee;

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public StoreEntity Update(int id, StoreEntity storee)
        {
            if (_dataContext.stores == null || storee== null)
                return null;
            StoreEntity s = _dataContext.stores.Find(id);
            if (s == null)
                return null;
            s.SiteStore = storee.SiteStore!=null?storee.SiteStore:s.SiteStore;
            s.City = storee.City!=null?storee.City:s.City;
            s.Email = storee.Email!=null ? storee.Email : s.Email;
            s.Address = storee.Address!=null?storee.Address:s.Address;
            s.Manager = storee.Manager!=null ? storee.Manager : s.Manager;
            s.StoreName = storee.StoreName!=null?storee.StoreName:s.StoreName;
            s.Phone = storee.Phone != null ? storee.Phone : s.Phone;
            try
            {
                _dataContext.SaveChanges();
                return storee;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Delete(int id)
        {
            if (_dataContext.stores == null || (_dataContext.stores.Find(id) == null))
                return false;
            _dataContext.stores.Remove(_dataContext.stores.Find( id));
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
