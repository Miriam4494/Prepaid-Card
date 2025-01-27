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
    public class PurchaseCenterController : ControllerBase
    {
        readonly IPurchaseCenterService _iService;
        private readonly IMapper _mapper;

        public PurchaseCenterController(IPurchaseCenterService iService,IMapper mapper)
        {
            _iService = iService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PurchaseCenterDTO>> Get()
        {
            var purchaseCenter= _iService.GetPurchaseCenters();
            if(purchaseCenter==null)
                return NotFound();
            return Ok(purchaseCenter);
        }

        [HttpGet("{id}")]
        public ActionResult<PurchaseCenterDTO> Get(int id)
        {
            var pc = _iService.GetPurchaseCenterById(id);
            if (pc == null)
                return NotFound();
            return pc;
        }
        [HttpPost]
        public ActionResult<PurchaseCenterDTO> Post([FromBody] PurchaseCenterPostModel purchasecenter)
        {
            var purchaseCenterDto = _mapper.Map<PurchaseCenterDTO>(purchasecenter);
            purchaseCenterDto = _iService.AddPurchaseCenter(purchaseCenterDto);
            if (purchaseCenterDto == null)
                return NotFound();
            return purchaseCenterDto;

        }

        [HttpPut("{id}")]
        public ActionResult<PurchaseCenterDTO> Put(int id, [FromBody] PurchaseCenterPostModel purchasecenter)
        {
            var purchaseCenterDto = _mapper.Map<PurchaseCenterDTO>(purchasecenter);
            purchaseCenterDto = _iService.UpdatePurchaseCenter(id, purchaseCenterDto);
            if (purchaseCenterDto == null)
                return NotFound();
            return purchaseCenterDto;
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.DeletePurchaseCenter(id);
        }
    }
}
