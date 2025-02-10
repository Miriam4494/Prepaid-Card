using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrepaidCard.API.PostModels;
using PrepaidCard.Core.DTOs;
using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces.IServices;
using PrepaidCard.Service.Services;

namespace PrepaidCard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {

        readonly ICardService _iService;
        private readonly IMapper _mapper;
        public CardController(ICardService iService,IMapper mapper)
        {
            _iService = iService;
            _mapper = mapper;
        }

        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardDTO>>> Get()
        {
            var card=await _iService.GetallAsync();
            if(card == null) 
                return NotFound();
            return Ok(card);
        }

        [HttpGet("{id}")]
        public ActionResult<CardDTO> Get(int id)
        {
            var c = _iService.GetCardById(id);
            if (c == null)
                return NotFound();
            return c;
        }

        [HttpPost]
        public ActionResult<CardDTO> Post([FromBody] CardPostModel card)
        {
            var cardDto = _mapper.Map<CardDTO>(card);
            cardDto = _iService.AddCard(cardDto);
            if (cardDto == null)
                return NotFound();
            return cardDto;

        }

        [HttpPut("{id}")]
        public ActionResult<CardDTO> Put(int id, [FromBody] CardPostModel card)
        {
            var cardDto = _mapper.Map<CardDTO>(card);
            cardDto = _iService.UpdateCard(id,cardDto);
            if (cardDto == null)
                return NotFound();
            return cardDto;
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.DeleteCard(id);
        }
    }
}
