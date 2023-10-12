using InstinctInventoryProject.BusinessLogic.Interface;
using InstinctInventoryProject.Domain.Dtos.Unit;
using InstinctInventoryProject.Domain.Response;
using Microsoft.AspNetCore.Mvc;

namespace InstinctInventoryProject.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnit _repo;

        public UnitController(IUnit repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUnits(int pageNumber, int pageSize)
        {
            var response = await _repo.GetUnits(pageNumber, pageSize);
            if (response.Code.Equals("00"))
            {
                return Ok(response);
            }
            else if (response.Code.Equals("01"))
            {
                return NotFound(response);
            }
            else
            {
                return StatusCode(500, new ErrorResponse { Code = response.Code, Description = response.Description });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetSingleUnit(int unitId)
        {
            var response = await _repo.GetSingleUnit(unitId);
            if (response.Code.Equals("00"))
            {
                return Ok(response);
            }
            else if (response.Code.Equals("01"))
            {
                return NotFound(response);
            }
            else
            {
                return StatusCode(500, new ErrorResponse { Code = response.Code, Description = response.Description });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUnit([FromBody] CreateUnitDto request)
        {
            var response = await _repo.CreateUnit(request);
            if (response.Code.Equals("00"))
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(500, new ErrorResponse { Code = response.Code, Description = response.Description });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUnit([FromBody] UpdateUnitDto request)
        {
            var response = await _repo.UpdateUnit(request);
            if (response.Code.Equals("00"))
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(500, new ErrorResponse { Code = response.Code, Description = response.Description });
            }
        }
    }
}