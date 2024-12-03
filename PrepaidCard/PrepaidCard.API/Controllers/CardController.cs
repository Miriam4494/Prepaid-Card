using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces;

namespace PrepaidCard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {

        readonly IService<CardEntity> _iService;
        public CardController(IService<CardEntity> iService)
        {
            _iService = iService;
        }
        // GET: api/<CleanerController>
        [HttpGet]
        public ActionResult<IEnumerable<CardEntity>> Get()
        {
            return _iService.Get();
        }

        // GET api/<CleanerController>/5
        [HttpGet("{id}")]
        public ActionResult<CardEntity> Get(int id)
        {
            CardEntity c = _iService.GetById(id);
            if (c == null)
                return NotFound();
            return c;
        }

        // POST api/<CleanerController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] CardEntity card)
        {
            return _iService.Add(card);
        }

        // PUT api/<CleanerController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] CardEntity card)
        {
            return _iService.Update(id, card);
        }

        // DELETE api/<CleanerController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.Delete(id);
        }
    }
}
