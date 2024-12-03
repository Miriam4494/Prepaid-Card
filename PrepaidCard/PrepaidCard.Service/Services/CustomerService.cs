using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Service.Services
{
    public class CustomerService : IService<CustomerEntity>
    {
        readonly IRepository<CustomerEntity> _iRepository;
        public CustomerService(IRepository<CustomerEntity> iRepository)
        {
            _iRepository = iRepository;
        }
        public List<CustomerEntity> Get()
        {
            return _iRepository.Get();
        }
        public CustomerEntity GetById(int id)
        {
            return _iRepository.GetById(id);
        }
        public bool Add(CustomerEntity order)
        {
            return _iRepository.Add(order);
        }
        public bool Update(int id, CustomerEntity order)
        {
            return _iRepository.Update(id, order);
        }
        public bool Delete(int id)
        {
            return _iRepository.Delete(id);
        }
    }
}
