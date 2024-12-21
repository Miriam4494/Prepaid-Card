using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces;

namespace PrepaidCard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        readonly CustomerIService _iService;
        public CustomerController(CustomerIService iService)
        {
            _iService = iService;
        }
        // GET: api/<CleanerController>
        [HttpGet]
        public ActionResult<IEnumerable<CustomerEntity>> Get()
        {
            return _iService.GetCustomers();
        }

        // GET api/<CleanerController>/5
        [HttpGet("{id}")]
        public ActionResult<CustomerEntity> Get(int id)
        {
            CustomerEntity c = _iService.GetCustomerById(id);
            if (c == null)
                return NotFound();
            return c;
        }

        // POST api/<CleanerController>
        [HttpPost]
        public ActionResult<CustomerEntity> Post([FromBody] CustomerEntity customer)
        {
            return _iService.AddCustomer(customer);
        }

        // PUT api/<CleanerController>/5
        [HttpPut("{id}")]
        public ActionResult<CustomerEntity> Put(int id, [FromBody] CustomerEntity customer)
        {
            return _iService.UpdateCustomer(id, customer);
        }

        // DELETE api/<CleanerController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.DeleteCustomer(id);
        }
    }
}
