using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces;

namespace PrepaidCard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseCenterController : ControllerBase
    {
        readonly IService<PurchaseCenterEntity> _iService;
        public PurchaseCenterController(IService<PurchaseCenterEntity> iService)
        {
            _iService = iService;
        }
        // GET: api/<CleanerController>
        [HttpGet]
        public ActionResult<IEnumerable<PurchaseCenterEntity>> Get()
        {
            return _iService.Get();
        }

        // GET api/<CleanerController>/5
        [HttpGet("{id}")]
        public ActionResult<PurchaseCenterEntity> Get(int id)
        {
            PurchaseCenterEntity pc = _iService.GetById(id);
            if (pc == null)
                return NotFound();
            return pc;
        }

        // POST api/<CleanerController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] PurchaseCenterEntity purchaseCenter)
        {
            return _iService.Add(purchaseCenter);
        }

        // PUT api/<CleanerController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] PurchaseCenterEntity purchaseCenter)
        {
            return _iService.Update(id, purchaseCenter);
        }

        // DELETE api/<CleanerController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.Delete(id);
        }
    }
}
