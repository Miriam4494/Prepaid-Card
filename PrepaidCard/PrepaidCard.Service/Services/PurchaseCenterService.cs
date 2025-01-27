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
    public class PurchaseCenterService : IPurchaseCenterService
    {
        readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;


        public PurchaseCenterService(IRepositoryManager iRepository,IMapper mapper)
        {
            _repositoryManager = iRepository;
            _mapper = mapper;
        }
        public IEnumerable<PurchaseCenterDTO> GetPurchaseCenters()
        {
            var purchases = _repositoryManager._purchaseCenterRepository.GetFull();
            return _mapper.Map<IEnumerable<PurchaseCenterDTO>>(purchases);
        }
        public PurchaseCenterDTO GetPurchaseCenterById(int id)
        {
            var purchase = _repositoryManager._purchaseCenterRepository.GetById(id);
            return _mapper.Map<PurchaseCenterDTO>(purchase);

        }

        public PurchaseCenterDTO AddPurchaseCenter(PurchaseCenterDTO purchase)
        {
            var p = _mapper.Map<PurchaseCenterEntity>(purchase);
            p = _repositoryManager._purchaseCenterRepository.Add(p);
            if (p != null)
                _repositoryManager.save();
            return _mapper.Map<PurchaseCenterDTO>(p);
        }
       
        public PurchaseCenterDTO UpdatePurchaseCenter(int id, PurchaseCenterDTO purchase)
        {

            var p = _mapper.Map<PurchaseCenterEntity>(purchase);

            p = _repositoryManager._purchaseCenterRepository.Update(id, p);
            if (p != null)
                _repositoryManager.save();
            return _mapper.Map<PurchaseCenterDTO>(p);

        }
        public bool DeletePurchaseCenter(int id)
            {
                bool succeed = _repositoryManager._purchaseCenterRepository.Delete(id);
                if (succeed)
                    _repositoryManager.save();
                return succeed;
            }
    }
}

