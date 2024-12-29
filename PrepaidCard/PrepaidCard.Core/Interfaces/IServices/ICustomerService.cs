using PrepaidCard.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepaidCard.Core.Interfaces.IServices
{
    public interface ICustomerService
    {
        public List<CustomerEntity> GetCustomers();
        public CustomerEntity GetCustomerById(int id);
        public CustomerEntity AddCustomer(CustomerEntity customer);
        public CustomerEntity UpdateCustomer(int id, CustomerEntity customer);
        public bool DeleteCustomer(int id);
    }
}
