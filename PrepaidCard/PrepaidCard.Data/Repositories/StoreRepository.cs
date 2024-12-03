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
        //שליפת רשימת חנויות
        public List<StoreEntity> Get()
        {

            return _dataContext.stores;
        }
        //שליפת חנות לפי מזהה חנות
        public StoreEntity GetById(int id)
        {
            if (_dataContext.stores == null || (_dataContext.stores.Find(s => s.StoreId == id) == null))
                return null;
            return _dataContext.stores.Find(store => store.StoreId == id);
        }
        #region פונקציות מיוחדות
        //שליפת חנות לפי שם חנות
        //public StoreEntity GetStoreByName(string name)
        //{
        //    if (DataManager.dataContexts.store == null || (DataManager.dataContexts.store.Find(s => s.StoreName == name) == null))
        //        return null;
        //    return DataManager.dataContexts.store.Find(store => store.StoreName == name);
        //}
        #endregion

        //הוספת חנות
        public bool Add(StoreEntity storee)
        {

            if (_dataContext.stores == null)
                _dataContext.stores = new List<StoreEntity>();
            if (_dataContext.stores.Find(s => s.StoreId == storee.StoreId) != null) return false;

            _dataContext.stores.Add(storee);
            return _dataContext.Save(_dataContext.stores, "Data/Stores.csv");

        }
        //עדכון חנות
        public bool Update(int id, StoreEntity storee)
        {
            if (_dataContext.stores == null || (_dataContext.stores.Find(s => s.StoreId == id) == null))
                return false;
            int index = _dataContext.stores.FindIndex(store => store.StoreId == id);

            _dataContext.stores[index].SiteStore = storee.SiteStore;
            _dataContext.stores[index].City = storee.City;
            _dataContext.stores[index].Email = storee.Email;
            _dataContext.stores[index].Address = storee.Address;
            _dataContext.stores[index].Manager = storee.Manager;
            _dataContext.stores[index].StoreName = storee.StoreName;
            _dataContext.stores[index].Phone = storee.Phone;
            return _dataContext.Save(_dataContext.stores, "Data/Stores.csv");

        }
        //מחיקת חנות
        public bool Delete(int id)
        {
            if (_dataContext.stores == null || (_dataContext.stores.Find(s => s.StoreId == id) == null))
                return false;
            _dataContext.stores.Remove(_dataContext.stores.Find(store => store.StoreId == id));
            return _dataContext.Save(_dataContext.stores, "Data/Stores.csv");

        }
    }
}
