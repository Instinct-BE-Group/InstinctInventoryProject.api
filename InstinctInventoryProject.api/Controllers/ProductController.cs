using InstinctInventoryProject.BusinessLogic.Interface;
using InstinctInventoryProject.Domain.Dtos.Product;
using InstinctInventoryProject.Domain.Response;
using Microsoft.AspNetCore.Mvc;

namespace InstinctInventoryProject.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _repo;

        public ProductController(IProduct repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(int pageNumber, int pageSize)
        {
            var res = await _repo.GetProducts(pageNumber, pageSize);
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
        public async Task<IActionResult> GetSingleProduct(int productId)
        {
            var res = await _repo.GetSingleProduct(productId);
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
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto request)
        {
            var res = await _repo.CreateProduct(request);
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
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto request)
        {
            var res = await _repo.UpdateProduct(request);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse { Code = res.Code, Description = res.Description });
            }
        }

        //[HttpDelete]
        //public async Task<IActionResult> DeleteProduct(int productId)
        //{
        //    var res = await _repo.DeleteProduct(productId);
        //    if (res.Code.Equals("00"))
        //    {
        //        return Ok(res);
        //    }
        //    else
        //    {
        //        return StatusCode(500, new ErrorResponse { Code = res.Code, Description = res.Description });
        //    }
        //}
    }
}
