using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Service.Services
{
    public class CustomerService : CustomerIService
    {
        readonly IRepository<CustomerEntity> _iRepository;
        public CustomerService(IRepository<CustomerEntity> iRepository)
        {
            _iRepository = iRepository;
        }
        public List<CustomerEntity> GetCustomers()
        {
            return _iRepository.Get();
        }
        public CustomerEntity GetCustomerById(int id)
        {
            return _iRepository.GetById(id);
        }
        public CustomerEntity AddCustomer(CustomerEntity order)
        {
            return _iRepository.Add(order);
        }
        public CustomerEntity UpdateCustomer(int id, CustomerEntity order)
        {
            return _iRepository.Update(id, order);
        }
        public bool DeleteCustomer(int id)
        {
            return _iRepository.Delete(id);
        }
    }
}
