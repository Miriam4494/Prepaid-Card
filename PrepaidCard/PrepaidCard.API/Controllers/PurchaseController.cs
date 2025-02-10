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
    public class PurchaseController : ControllerBase
    {
        readonly IPurchaseService _iService;
        private readonly IMapper _mapper;

        public PurchaseController(IPurchaseService iService,IMapper mapper)
        {
            _iService = iService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseDTO>>> Get()
        {
            var purchase = await _iService.GetallAsync();
            if (purchase == null)
                return NotFound();
            return Ok(purchase);
        }

        [HttpGet("{id}")]
        public ActionResult<PurchaseDTO> Get(int id)
        {
            var p = _iService.GetPurchaseById(id);
            if (p == null)
                return NotFound();
            return p;
        }

        [HttpPost]
        public ActionResult<PurchaseDTO> Post([FromBody] PurchasePostModel purchase)
        {
            var purchaseDto = _mapper.Map<PurchaseDTO>(purchase);
            purchaseDto = _iService.AddPurchase(purchaseDto);
            if (purchaseDto == null)
                return NotFound();
            return purchaseDto;

        }

        [HttpPut("{id}")]
        public ActionResult<PurchaseDTO> Put(int id, [FromBody] PurchasePostModel purchase)
        {
            var purchaseDto = _mapper.Map<PurchaseDTO>(purchase);
            purchaseDto = _iService.UpdatePurchase(id, purchaseDto);
            if (purchaseDto == null)
                return NotFound();
            return purchaseDto;
        }


        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _iService.DeletePurchase(id);
        }
    }
}
