using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces.IRepositories;
using PrepaidCard.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PrepaidCard.Service.Services
{
    public class CardService: ICardService
    {
        readonly IRepositoryManager _repositoryManager;

        public CardService(IRepositoryManager iRepository)
        {
            _repositoryManager = iRepository;
        }
        public List<CardEntity> GetCards()
        {
                //return _repositoryManager._cardRepository.Get();
                return _repositoryManager._cardRepository.GetFull();
        }
            public CardEntity GetCardById(int id)
            {
                return _repositoryManager._cardRepository.GetById(id);
            }
            //public bool IsValidTz(string tz)
            //{
            //    if (tz.Length != 9)
            //        return false;
            //    int sum = 0, i = 0, plus;
            //    while (i < tz.Length - 1)
            //    {
            //        if (tz[i] < '0' || tz[i] > '9')
            //            return false;
            //        plus = tz[i] - '0';
            //        if (i % 2 == 1)
            //            plus *= 2;
            //        if (plus > 9)
            //            plus = plus / 10 + plus % 10;
            //        sum += plus;
            //        i++;
            //    }
            //    sum %= 10;
            //    if (10 - sum == tz[tz.Length - 1] - '0')
            //        return true;
            //    return false;
            //}
            public CardEntity AddCard(CardEntity cleaner) 
            { 
                CardEntity c = _repositoryManager._cardRepository.Add( cleaner);
                if (c!=null)
                    _repositoryManager.save();
                return c;
            
            }
            public CardEntity UpdateCard(int id, CardEntity cleaner)
            {
                
                CardEntity c = _repositoryManager._cardRepository.Update(id, cleaner);
                if (c!=null)
                    _repositoryManager.save();
                return c;

        }
            public bool DeleteCard(int id)
            {
                bool succeed = _repositoryManager._cardRepository.Delete(id);
                if (succeed)
                    _repositoryManager.save();
                return succeed;
            
            }

        
    }
}



