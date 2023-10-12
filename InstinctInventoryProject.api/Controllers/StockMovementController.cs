using InstinctInventoryProject.BusinessLogic.Interface;
using InstinctInventoryProject.Domain.Dtos.StockMovement;
using InstinctInventoryProject.Domain.Response;
using Microsoft.AspNetCore.Mvc;

namespace InstinctInventoryProject.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StockMovementController : ControllerBase
    {
        private readonly IStockMovement _repo;

        public StockMovementController(IStockMovement repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStockMovement([FromBody] CreateStockMovementDto request)
        {
            var res = await _repo.CreateStockMovement(request);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse { Code = res.Code, Description = res.Description });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStockMovement([FromBody] UpdateStockMovementDto request)
        {
            var res = await _repo.UpdateStockMovement(request);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse { Code = res.Code, Description = res.Description });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetStockMovementsByProductId(int productId, int pageNumber, int pageSize)
        {
            var res = await _repo.GetStockMovementsByProductId(productId, pageNumber, pageSize);
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
                return StatusCode(500, new ErrorResponse { Code = res.Code, Description = res.Description });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetStockMovementsByUnitId(int unitId, int pageNumber, int pageSize)
        {
            var res = await _repo.GetStockMovementsByUnitId(unitId, pageNumber, pageSize);
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
                return StatusCode(500, new ErrorResponse { Code = res.Code, Description = res.Description });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetStockMovementByMovementId(int movementId)
        {
            var res = await _repo.GetStockMovementByMovementId(movementId);
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
                return StatusCode(500, new ErrorResponse { Code = res.Code, Description = res.Description });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStockMovements(int pageNumber, int pageSize)
        {
            var res = await _repo.GetAllStockMovements(pageNumber, pageSize);
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
                return StatusCode(500, new ErrorResponse { Code = res.Code, Description = res.Description });
            }
        }
    }
}