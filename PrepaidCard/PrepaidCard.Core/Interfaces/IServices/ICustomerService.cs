using PrepaidCard.Core.DTOs;
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
        public Task<IEnumerable<CustomerDTO>> GetallAsync();
        public CustomerDTO GetCustomerById(int id);
        public CustomerDTO AddCustomer(CustomerDTO customer);
        public CustomerDTO UpdateCustomer(int id, CustomerDTO customer);
        public bool DeleteCustomer(int id);
    }
}
