using Microsoft.EntityFrameworkCore;
using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PrepaidCard.Data.Repositories.CardRepository;

namespace PrepaidCard.Data.Repositories
{

    public class CardRepository:Repository<CardEntity>,ICardRepository
    {
            public CardRepository(DataContext dataContext): base(dataContext)
            {
              
            }
            public List<CardEntity> GetFull()
            {
                return _dbSet.Include(p => p.Purchase).ToList();
            }







            //readonly DataContext _dataContext;
            //public CardRepository(DataContext dataContext)
            //{
            //    _dataContext = dataContext;
            //}
            //public readonly DataContext _context;
            ////get cards

            //public List<CardEntity> Get()
            //{
            //    return _dataContext.cards.ToList();
            //}

            ////get card by id

            //public CardEntity GetById(int id)
            //{

            //    if (_dataContext.cards == null || (_dataContext.cards.ToList().FindIndex(c => c.CardId == id) == -1))
            //        return null;
            //    return _dataContext.cards.Find( id);


            //}
            //#region especial function
            ////שליפת כרטיס לפי מזהה לקוח
            ////public CardEntity GetCardByCustomer(int id)
            ////{
            ////    if (DataManager.dataContexts.cards == null || (DataManager.dataContexts.cards.FindIndex(c => c.CustomerId == id) == -1))
            ////        return null;
            ////    return DataManager.dataContexts.cards.Find(card => card.CustomerId == id);
            ////}
            //#endregion

            ////add card
            //public CardEntity Add(CardEntity card)
            //{
            //    if (_dataContext.cards.Find( card.CardId) != null) return null;

            //    _dataContext.cards.Add(card);
            //    try
            //    {
            //        _dataContext.SaveChanges();
            //        return card;

            //    }
            //    catch (Exception ex)
            //    {
            //        return null;
            //    }
            //}

            ////update card

            //public CardEntity Update(int id, CardEntity card)
            //{

            //    if (_dataContext.cards == null ||card == null)
            //        return null;
            //    CardEntity c = _dataContext.cards.Find(id);
            //    if (c == null)
            //        return null;

            //    c.ColorCard = card.ColorCard!=null? card.ColorCard: c.ColorCard;
            //    c.CustomerId = card.CustomerId!=null? card.CustomerId: c.CustomerId;
            //    c.CardValidity = card.CardValidity!=null? card.CardValidity: c.CardValidity;
            //    c.PurchaseCenter = card.PurchaseCenter!=null? card.PurchaseCenter : c.PurchaseCenter;
            //    c.Sum = card.Sum!=null? card.Sum: c.Sum;
            //    c.PurchaseCenter = card.PurchaseCenter!=null? card.PurchaseCenter : c.PurchaseCenter;
            //    c.DateOfPurchase = card.DateOfPurchase!=null? card.DateOfPurchase: c.DateOfPurchase;
            //    try
            //    {
            //        _dataContext.SaveChanges();
            //        return card;

            //    }
            //    catch (Exception ex)
            //    {
            //        return null;
            //    }
            //}
            ////delete card
            //public bool Delete(int id)
            //{

            //    if (_dataContext.cards == null || (_dataContext.cards.Find(id) == null))
            //        return false;
            //    _dataContext.cards.Remove(_dataContext.cards.Find( id));
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
