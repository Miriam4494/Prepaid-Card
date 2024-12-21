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

        readonly CardIService _iService;
        public CardController(CardIService iService)
        {
            _iService = iService;
        }
        // GET: api/<CleanerController>
        [HttpGet]
        public ActionResult<IEnumerable<CardEntity>> Get()
        {
            return _iService.GetCards();
        }

        // GET api/<CleanerController>/5
        [HttpGet("{id}")]
        public ActionResult<CardEntity> Get(int id)
        {
            CardEntity c = _iService.GetCardById(id);
            if (c == null)
                return NotFound();
            return c;
        }

        // POST api/<CleanerController>
        [HttpPost]
        public ActionResult<CardEntity> Post([FromBody] CardEntity card)
        {
            return _iService.AddCard(card);
        }

        // PUT api/<CleanerController>/5
        [HttpPut("{id}")]
        public ActionResult<CardEntity> Put(int id, [FromBody] CardEntity card)
        {
            return _iService.UpdateCard(id, card);
        }

        // DELETE api/<CleanerController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.DeleteCard(id);
        }
    }
}
