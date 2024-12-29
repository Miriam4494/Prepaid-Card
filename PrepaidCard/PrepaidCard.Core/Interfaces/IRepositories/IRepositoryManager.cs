using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Core.Interfaces.IRepositories
{
    public interface IRepositoryManager
    {

        ICardRepository _cardRepository { get; }
        ICustomerRepository _customerRepository { get; }
        IPurchaseRepository _purchaseRepository { get; }
        IPurchaseCenterRepository _purchaseCenterRepository { get; }
       IStoreRepository _storeRepository { get; }


        void save();

    }
}
