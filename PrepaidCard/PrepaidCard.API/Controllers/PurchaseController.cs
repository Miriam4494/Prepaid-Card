using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces;

namespace PrepaidCard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        readonly PurchaseIService _iService;
        public PurchaseController(PurchaseIService iService)
        {
            _iService = iService;
        }
        // GET: api/<CleanerController>
        [HttpGet]
        public ActionResult<IEnumerable<PurchaseEntity>> Get()
        {
            return _iService.GetPurchases();
        }

        // GET api/<CleanerController>/5
        [HttpGet("{id}")]
        public ActionResult<PurchaseEntity> Get(int id)
        {
            PurchaseEntity p = _iService.GetPurchaseById(id);
            if (p == null)
                return NotFound();
            return p;
        }

        // POST api/<CleanerController>
        [HttpPost]
        public ActionResult<PurchaseEntity> Post([FromBody] PurchaseEntity purchase)
        {
            return _iService.AddPurchase(purchase);
        }

        // PUT api/<CleanerController>/5
        [HttpPut("{id}")]
        public ActionResult<PurchaseEntity> Put(int id, [FromBody] PurchaseEntity purchase)
        {
            return _iService.UpdatePurchase(id, purchase);
        }

        // DELETE api/<CleanerController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.DeletePurchase(id);
        }
    }
}
