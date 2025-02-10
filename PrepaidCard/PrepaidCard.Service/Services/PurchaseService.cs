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
    public class PurchaseService:IPurchaseService
    {
        readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public PurchaseService(IRepositoryManager iRepository,IMapper mapper)
        {
            _repositoryManager = iRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PurchaseDTO>> GetallAsync()
        {
            var purchases = _repositoryManager._purchaseRepository.GetFullAsync();
            return _mapper.Map<IEnumerable<PurchaseDTO>>(purchases);
        }
        public PurchaseDTO GetPurchaseById(int id)
        {
            var purchase = _repositoryManager._purchaseRepository.GetById(id);
            return _mapper.Map<PurchaseDTO>(purchase);

        }

        public PurchaseDTO AddPurchase(PurchaseDTO purchase)
        {
            var p = _mapper.Map<PurchaseEntity>(purchase);
            p = _repositoryManager._purchaseRepository.Add(p);
            if (p != null)
                _repositoryManager.save();
            return _mapper.Map<PurchaseDTO>(p);
        }
        public PurchaseDTO UpdatePurchase(int id, PurchaseDTO purchase)
        {

            var p = _mapper.Map<PurchaseEntity>(purchase);

            p= _repositoryManager._purchaseRepository.Update(id, p);
            if (p != null)
                _repositoryManager.save();
            return _mapper.Map<PurchaseDTO>(p);

        }
        public bool DeletePurchase(int id)
        {
            bool succeed = _repositoryManager._purchaseRepository.Delete(id);
            if (succeed)
                _repositoryManager.save();
            return succeed;
        }
    }
}
