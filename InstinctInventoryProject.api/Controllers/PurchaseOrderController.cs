using InstinctInventoryProject.BusinessLogic.Interface;
using InstinctInventoryProject.Domain.Dtos.PurchaseOrder;
using InstinctInventoryProject.Domain.Response;
using Microsoft.AspNetCore.Mvc;

namespace InstinctInventoryProject.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrder _repo;

        public PurchaseOrderController(IPurchaseOrder repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<object> GetPurchaseOrder(int pageNumber, int pageSize)
        {
            var res = await _repo.GetPurchases(pageNumber, pageSize);
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
        public async Task<object> GetSinglePurchaseOrder(int Id)
        {
            var res = await _repo.SinglePurchase(Id);
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
        public async Task<ActionResult> CreatePurchaseOrder([FromBody] CreatePurchaseOrderDto request)
        {
            var res = await _repo.CreatePurchaseOrder(request);
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
        public async Task<ActionResult> UpdateExpense([FromBody] UpdatePurchaseOrderDto request)
        {
            var res = await _repo.UpdatePurchaseOrder(request);
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