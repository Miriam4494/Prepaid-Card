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
    public class CustomerService : ICustomerService
    {
        readonly IRepositoryManager _repositoryManager;

        public CustomerService(IRepositoryManager iRepository)
        {
            _repositoryManager = iRepository;
        }
        public List<CustomerEntity> GetCustomers()
        {
            //return _repositoryManager._customerRepository.Get();
            return _repositoryManager._customerRepository.GetFull();
        }
        public CustomerEntity GetCustomerById(int id)
        {
            return _repositoryManager._customerRepository.GetById(id);
        }
        public CustomerEntity AddCustomer(CustomerEntity order)
        {
            CustomerEntity o = _repositoryManager._customerRepository.Add(order);
            if (o != null)
                _repositoryManager.save();
            return o;
        }
        public CustomerEntity UpdateCustomer(int id, CustomerEntity order)
        {
            CustomerEntity o = _repositoryManager._customerRepository.Update(id, order);
            if (o != null)
                _repositoryManager.save();
            return o;
        }
        public bool DeleteCustomer(int id)
        {
            bool succeed = _repositoryManager._customerRepository.Delete(id);
            if (succeed)
                _repositoryManager.save();
            return succeed;
        }

    }
}
