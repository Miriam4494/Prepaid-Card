using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Data.Repositories
{

    public class CardRepository:IRepository<CardEntity>
    {
        readonly DataContext _dataContext;
        public CardRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public readonly DataContext _context;
        //שליפת רשימת כרטיסים
        //public List<CardEntity> GetCards()
        //{
        //    return DataManager.dataContexts.cards;
        //}
        public List<CardEntity> Get()
        {
            return _dataContext.cards;
        }

        //שליפת כרטיס לפי מזהה
        //public CardEntity GetCardByID(int id)
        //{
        //    if (DataManager.dataContexts.cards == null || (DataManager.dataContexts.cards.FindIndex(c => c.CardId == id) == -1))
        //        return null;
        //    return DataManager.dataContexts.cards.Find(card => card.CardId == id);
        //}
        public CardEntity GetById(int id)
        {

            if (_dataContext.cards == null || (_dataContext.cards.FindIndex(c => c.CardId == id) == -1))
                return null;
            return _dataContext.cards.Find(c => c.CardId == id);


        }
        #region פונקציות מיוחדות
        //שליפת כרטיס לפי מזהה לקוח
        //public CardEntity GetCardByCustomer(int id)
        //{
        //    if (DataManager.dataContexts.cards == null || (DataManager.dataContexts.cards.FindIndex(c => c.CustomerId == id) == -1))
        //        return null;
        //    return DataManager.dataContexts.cards.Find(card => card.CustomerId == id);
        //}
        #endregion



        //הוספת כרטיס
        //public bool AddCard(CardEntity card)
        //{ 
        //    if (DataManager.dataContexts.cards == null)
        //        DataManager.dataContexts.cards = new List<CardEntity>();
        //    if(DataManager.dataContexts.cards.Find(c => c.CardId == card.CardId)!=null) return false;
        //    DataManager.dataContexts.cards.Add(card);
        //    return true;
        //}




        public bool Add(CardEntity card)
        {
            if (_dataContext.cards == null)
                _dataContext.cards = new List<CardEntity>();
            if (_dataContext.cards.Find(c => c.CardId == card.CardId) != null) return false;

            _dataContext.cards.Add(card);
            return _dataContext.Save(_dataContext.cards, "Data/Cards.csv");
        }

        //עדכון פרטי כרטיס
        //public bool UpdateCard(int id, CardEntity card)
        //{
        //    if (DataManager.dataContexts.cards == null || (DataManager.dataContexts.cards.FindIndex(c => c.CardId == id) == -1))
        //        return false;
        //    int index = DataManager.dataContexts.cards.FindIndex(card => card.CardId == id);
        //    DataManager.dataContexts.cards[index].ColorCard = card.ColorCard;
        //    DataManager.dataContexts.cards[index].CardValidity = card.CardValidity;
        //    DataManager.dataContexts.cards[index].PurchaseCenter = card.PurchaseCenter;
        //    DataManager.dataContexts.cards[index].Sum = card.Sum;
        //    DataManager.dataContexts.cards[index].PurchaseCenter = card.PurchaseCenter;
        //    DataManager.dataContexts.cards[index].DateOfPurchase = card.DateOfPurchase;
        //    return true;
        //}

        public bool Update(int id, CardEntity card)
        {
            if (_dataContext.cards == null || (_dataContext.cards.Find(c => c.CardId == id) == null))
                return false;
            int index = _dataContext.cards.FindIndex(c => c.CardId == id);
            _dataContext.cards[index].ColorCard = card.ColorCard;
            _dataContext.cards[index].CustomerId = card.CustomerId;
            _dataContext.cards[index].CardValidity = card.CardValidity;
            _dataContext.cards[index].PurchaseCenter = card.PurchaseCenter;
            _dataContext.cards[index].Sum = card.Sum;
            _dataContext.cards[index].PurchaseCenter = card.PurchaseCenter;
            _dataContext.cards[index].DateOfPurchase = card.DateOfPurchase;
            return _dataContext.Save(_dataContext.cards, "Data/Cards.csv");
        }



        //מחיקת כרטיס
        //public bool DeleteCard(int id)
        //{
        //    if (DataManager.dataContexts.cards == null || (DataManager.dataContexts.cards.FindIndex(c => c.CardId == id) == -1))
        //        return false;
        //    DataManager.dataContexts.cards.Remove(DataManager.dataContexts.cards.Find(card => card.CardId == id));
        //    return true;
        //}

        public bool Delete(int id)
        {

            if (_dataContext.cards == null || (_dataContext.cards.Find(c => c.CardId == id) == null))
                return false;
            _dataContext.cards.Remove(_dataContext.cards.Find(c => c.CardId == id));
            return _dataContext.Save(_dataContext.cards, "Data/Cards.csv");

        }
    }
}
