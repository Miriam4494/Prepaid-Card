using PrepaidCard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Core.Interfaces
{
    public interface CardIService
    {
        public List<CardEntity> GetCards();
        public CardEntity GetCardById(int id);
        public CardEntity AddCard(CardEntity card);
        public CardEntity UpdateCard(int id, CardEntity card);
        public bool DeleteCard(int id);
    }
}
