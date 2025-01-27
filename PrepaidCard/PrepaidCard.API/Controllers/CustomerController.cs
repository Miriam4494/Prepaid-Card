using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrepaidCard.API.PostModels;
using PrepaidCard.Core.DTOs;
using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces.IServices;

namespace PrepaidCard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        readonly ICustomerService _iService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService iService,IMapper mapper)
        {
            _iService = iService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CardDTO>> Get()
        {
            var customer= _iService.GetCustomers();
            if(customer == null) 
                return NotFound();
            return Ok(customer);
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerDTO> Get(int id)
        {
            var c = _iService.GetCustomerById(id);
            if (c == null)
                return NotFound();
            return c;
        }
        [HttpPost]
        public ActionResult<CustomerDTO> Post([FromBody] CustomerPostModel customer)
        {
            var customerDto = _mapper.Map<CustomerDTO>(customer);
            customerDto = _iService.AddCustomer(customerDto);
            if (customerDto == null)
                return NotFound();
            return customerDto;

        }

        [HttpPut("{id}")]
        public ActionResult<CustomerDTO> Put(int id, [FromBody] CustomerPostModel card)
        {
            var customerDto = _mapper.Map<CustomerDTO>(card);
            customerDto = _iService.UpdateCustomer(id, customerDto);
            if (customerDto == null)
                return NotFound();
            return customerDto;
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.DeleteCustomer(id);
        }
    }
}
