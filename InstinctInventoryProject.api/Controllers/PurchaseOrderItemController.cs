using InstinctInventoryProject.BusinessLogic.Interface;
using InstinctInventoryProject.BusinessLogic.Repository;
using InstinctInventoryProject.Domain.Dtos.PurchaseOrderItem;
using InstinctInventoryProject.Domain.Response;
using Microsoft.AspNetCore.Mvc;

namespace InstinctInventoryProject.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PurchaseOrderItemController : ControllerBase
    {
        private readonly IPurchaseOrderItems _repo;

        public PurchaseOrderItemController(IPurchaseOrderItems repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<object> GetPurchaseOrderItem(int pageNumber, int pageSize)
        {
            var res = await _repo.GetPurchaseOrderItem(pageNumber, pageSize);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else if (res.Code.Equals("01"))
            {
                return NotFound(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse() { Code = res.Code, Description = res.Description });
            }
        }

        [HttpGet]
        public async Task<object> GetSinglePurchaseOrderItem(int Id)
        {
            var res = await _repo.SinglePurchaseOrderItem(Id);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else if (res.Code.Equals("01"))
            {
                return NotFound(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse() { Code = res.Code, Description = res.Description });
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreatePurchaseOrderItem([FromBody]CreatePurchaseOrderItemDto request)
        {
            var res = await _repo.CreatePurchaseOrderItem(request);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else if (res.Code.Equals("06"))
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse() { Code = res.Code, Description = res.Description });
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePurchaseOrderItem([FromBody] UpdatePurchaseOrderItemDto request)
        {
            var res = await _repo.UpdatePurchaseOrderItem(request);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse() { Code = res.Code, Description = res.Description });
            }
        }
    }
}