using PrepaidCard.Core.Entities; 
using PrepaidCard.Core.Interfaces; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PrepaidCard.Service.Services
{
    public class CardService: IService<CardEntity>
    {
        readonly IRepository<CardEntity> _iRepository;
        public CardService(IRepository<CardEntity> iRepository)
        {
            _iRepository = iRepository;
        }
        public List<CardEntity> Get()
        {
                return _iRepository.Get();
        }
            public CardEntity GetById(int id)
            {
                return _iRepository.GetById(id);
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
            public bool Add(CardEntity cleaner)
            {
                 return _iRepository.Add(cleaner);
            }
            public bool Update(int id, CardEntity cleaner)
            {
                 return _iRepository.Update(id, cleaner);
            }
            public bool Delete(int id)
            {
                return _iRepository.Delete(id);
            }
    }
}



