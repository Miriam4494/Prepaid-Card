using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces;

namespace PrepaidCard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        readonly IService<StoreEntity> _iService;
        public StoreController(IService<StoreEntity> iService)
        {
            _iService = iService;
        }
        // GET: api/<CleanerController>
        [HttpGet]
        public ActionResult<IEnumerable<StoreEntity>> Get()
        {
            return _iService.Get();
        }

        // GET api/<CleanerController>/5
        [HttpGet("{id}")]
        public ActionResult<StoreEntity> Get(int id)
        {
            StoreEntity s = _iService.GetById(id);
            if (s == null)
                return NotFound();
            return s;
        }

        // POST api/<CleanerController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] StoreEntity store)
        {
            return _iService.Add(store);
        }

        // PUT api/<CleanerController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] StoreEntity store)
        {
            return _iService.Update(id, store);
        }

        // DELETE api/<CleanerController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.Delete(id);
        }
    }
}
