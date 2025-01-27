using AutoMapper;
using PrepaidCard.Core.DTOs;
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
    public class CardService : ICardService
    {
        readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;


        public CardService(IRepositoryManager iRepository,IMapper mapper)
        {
            _repositoryManager = iRepository;
            _mapper = mapper;
        }

        public IEnumerable<CardDTO> GetCards()
        {
            var cards= _repositoryManager._cardRepository.GetFull();
           return _mapper.Map<IEnumerable<CardDTO>>(cards);
        }
        public CardDTO GetCardById(int id)
        {
            var cards= _repositoryManager._cardRepository.GetById(id);
            return _mapper.Map<CardDTO>(cards);

        }

        public CardDTO AddCard(CardDTO card)
        {
            var c = _mapper.Map<CardEntity>(card);
            c = _repositoryManager._cardRepository.Add(c);
            if (c != null)
                _repositoryManager.save();
            return _mapper.Map<CardDTO>(c);
        }
        public CardDTO UpdateCard(int id, CardDTO card)
        {
           
            var c = _mapper.Map<CardEntity>(card);

            c = _repositoryManager._cardRepository.Update(id, c);
            if (c != null)
                _repositoryManager.save();
            return _mapper.Map<CardDTO>(c);

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



