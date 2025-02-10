using AutoMapper;
using PrepaidCard.Core;
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
    public class CustomerService : ICustomerService
    {
        readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;


        public CustomerService(IRepositoryManager iRepository, IMapper mapper)
        {
            _repositoryManager = iRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CustomerDTO>> GetallAsync()
        {
            var customers = _repositoryManager._customerRepository.GetFullAsync();
            return _mapper.Map<IEnumerable<CustomerDTO>>(customers);
        }

        public CustomerDTO GetCustomerById(int id)
        {
            var customer = _repositoryManager._customerRepository.GetById(id);
            return _mapper.Map<CustomerDTO>(customer);

        }

        public CustomerDTO AddCustomer(CustomerDTO customer)
        {
           // if (ValidationCheck.IsEmailValid(customer.Email) && ValidationCheck.IsTzValid(customer.TZ))
            //{
                var c = _mapper.Map<CustomerEntity>(customer);
                c = _repositoryManager._customerRepository.Add(c);
                if (c != null)
                    _repositoryManager.save();

                return _mapper.Map<CustomerDTO>(c);
            
           // }
           // return null;
        }
        public CustomerDTO UpdateCustomer(int id, CustomerDTO customer)
        {
           // if (ValidationCheck.IsEmailValid(customer.Email) && ValidationCheck.IsTzValid(customer.TZ))
           // {
                var c = _mapper.Map<CustomerEntity>(customer);

                c = _repositoryManager._customerRepository.Update(id, c);
                if (c != null)
                    _repositoryManager.save();
                return _mapper.Map<CustomerDTO>(c);
           // }
            
            //return null;

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
