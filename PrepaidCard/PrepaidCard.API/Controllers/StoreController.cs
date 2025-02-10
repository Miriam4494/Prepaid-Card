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
    public class StoreController : ControllerBase
    {
        readonly IStoreService _iService;
        private readonly IMapper _mapper;

        public StoreController(IStoreService iService,IMapper mapper)
        {
            _iService = iService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreDTO>>> Get()
        {
            var store = await _iService.GetallAsync();
            if (store == null)
                return NotFound();
            return Ok(store);
        }
        

        [HttpGet("{id}")]
        public ActionResult<StoreDTO> Get(int id)
        {
            var s = _iService.GetStoreById(id);
            if (s == null)
                return NotFound();
            return s;
        }

        [HttpPost]
        public ActionResult<StoreDTO> Post([FromBody] StorePostModel store)
        {
            var storeDto = _mapper.Map<StoreDTO>(store);
            storeDto = _iService.AddStore(storeDto);
            if (storeDto == null)
                return NotFound();
            return storeDto;

        }

        [HttpPut("{id}")]
        public ActionResult<StoreDTO> Put(int id, [FromBody] StorePostModel store)
        {
            var storeDto = _mapper.Map<StoreDTO>(store);
            storeDto = _iService.UpdateStore(id, storeDto);
            if (storeDto == null)
                return NotFound();
            return storeDto;
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.DeleteStore(id);
        }
    }
}
