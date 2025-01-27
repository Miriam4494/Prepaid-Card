using PrepaidCard.Core.DTOs;
using PrepaidCard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Core.Interfaces.IServices
{
    public interface ICardService
    {
        public IEnumerable<CardDTO> GetCards();
        public CardDTO GetCardById(int id);
        public CardDTO AddCard(CardDTO card);
        public CardDTO UpdateCard(int id, CardDTO card);
        public bool DeleteCard(int id);
    }
}
