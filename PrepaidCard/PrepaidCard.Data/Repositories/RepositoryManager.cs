using PrepaidCard.Core.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        DataContext _dataContext;
        public ICardRepository _cardRepository { get; }
        public ICustomerRepository _customerRepository { get; }
        public IPurchaseRepository _purchaseRepository { get; }
        public IPurchaseCenterRepository _purchaseCenterRepository { get; }
        public IStoreRepository _storeRepository { get; }
        public RepositoryManager(DataContext dataContext, ICardRepository card, IStoreRepository store,ICustomerRepository customer,IPurchaseCenterRepository purchaseCenter,IPurchaseRepository purchase)
        {
            _dataContext = dataContext;
            _cardRepository = card;
            _customerRepository = customer;
            _purchaseRepository = purchase;
            _purchaseCenterRepository = purchaseCenter;
            _storeRepository = store;

        }
        public void save()
        {
            _dataContext.SaveChanges();
        }



       
        
    }
}
