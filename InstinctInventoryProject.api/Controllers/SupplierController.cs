using AutoMapper;
using InstinctInventoryProject.BusinessLogic.Interface;
using InstinctInventoryProject.Domain.Dtos.Supplier;
using InstinctInventoryProject.Domain.Models;
using InstinctInventoryProject.Domain.Response;
using Microsoft.AspNetCore.Mvc;

namespace InstinctInventoryProject.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplier _repo;
        private readonly IMapper _mapper;

        public SupplierController(ISupplier repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSuppliers(int pageNumber, int pageSize)
        {
            var res = await _repo.GetSuppliers(pageNumber, pageSize);
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
        public async Task<IActionResult> GetSingleSupplier(int supplierId)
        {
            var res = await _repo.GetSingleSupplier(supplierId);
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

        [HttpPost]
        public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierDto request)
        {
            var supplier = _mapper.Map<Supplier>(request);
            var res = await _repo.CreateSupplier(request);
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
        public async Task<IActionResult> UpdateSupplier([FromBody] UpdateSupplierDto request)
        {
            var supplier = _mapper.Map<Supplier>(request);
            var res = await _repo.UpdateSupplier(request);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse { Code = res.Code, Description = res.Description });
            }
        }
    }
}