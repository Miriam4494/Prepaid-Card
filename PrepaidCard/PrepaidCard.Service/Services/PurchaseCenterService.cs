using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Service.Services
{
    public class PurchaseCenterService : IService<PurchaseCenterEntity>
    {
       
        
            readonly IRepository<PurchaseCenterEntity> _iRepository;
            public PurchaseCenterService(IRepository<PurchaseCenterEntity> iRepository)
            {
                _iRepository = iRepository;
            }
            public List<PurchaseCenterEntity> Get()
            {
                return _iRepository.Get();
            }
            public PurchaseCenterEntity GetById(int id)
            {
                return _iRepository.GetById(id);
            }
            public bool Add(PurchaseCenterEntity order)
            {
                return _iRepository.Add(order);
            }
            public bool Update(int id, PurchaseCenterEntity order)
            {
                return _iRepository.Update(id, order);
            }
            public bool Delete(int id)
            {
                return _iRepository.Delete(id);
            }
    }
}

