using AutoMapper;
using InstinctInventoryProject.BusinessLogic.Interface;
using InstinctInventoryProject.Domain.Dtos.Product;
using InstinctInventoryProject.Domain.Models;
using InstinctInventoryProject.Domain.Response;
using Newtonsoft.Json;
using System.Data;

namespace InstinctInventoryProject.BusinessLogic.Respository
{
    public class ProductRepo : IProduct
    {
        private readonly IDbConnection _connection;
        private readonly DataAccess.Database.ProductDbService service;
        private readonly IMapper _mapper;

        public ProductRepo(IDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
            service = new DataAccess.Database.ProductDbService(connection);
        }

        public async Task<APIResponse<CreateProductDto>> CreateProduct(CreateProductDto request)
        {
            var response = new APIResponse<CreateProductDto>();
            var model = _mapper.Map<Product>(request);
            var result = await service.CreateProduct(model);

            if (result == 1)
            {
                response.Code = "00";
                response.Description = "Successful";
                response.Data = request;
            }
            else if (result == -1)
            {
                response.Code = "01";
                response.Description = "Record Already Exists";
            }
            else
            {
                response.Code = "99";
                response.Description = "An Error Occurred, Please try again later";
            }
            return response;
        }

        public async Task<APIListResponse3<Product>> GetProducts(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Product>();
            var result = await service.GetProducts(pageNumber, pageSize);
            if (result != null)
            {
                if (result.Data.Count() > 0)
                {
                    var metadata = new
                    {
                        result.Data.TotalCount,
                        result.Data.PageSize,
                        result.Data.CurrentPage,
                        result.Data.TotalPages,
                        result.Data.HasNext,
                        result.Data.HasPrevious
                    };
                    response.PageInfo = JsonConvert.SerializeObject(metadata);
                    response.Code = "00";
                    response.Description = "Successful";
                    response.Data = result.Data;
                }
                else
                {
                    response.Code = "01";
                    response.Description = "No Record Found";
                }
            }
            else
            {
                response.Code = "99";
                response.Description = "An Error Occurred, Please try again later";
            }
            return response;
        }

        public async Task<APIResponse<Product>> GetSingleProduct(int productId)
        {
            var response = new APIResponse<Product>();
            var result = await service.GetProduct(productId);

            if (result != null)
            {
                if (result.ProductId == 0)
                {
                    response.Code = "01";
                    response.Description = "No Record Found";
                }
                else
                {
                    response.Code = "00";
                    response.Description = "Successful";
                    response.Data = result;
                }
            }
            else
            {
                response.Code = "01";
                response.Description = "No Record Found";
            }
            return response;
        }

        public async Task<APIResponse<UpdateProductDto>> UpdateProduct(UpdateProductDto request)
        {
            var response = new APIResponse<UpdateProductDto>();
            var model = _mapper.Map<Product>(request);
            var result = await service.UpdateProduct(model);

            if (result == 1)
            {
                response.Code = "00";
                response.Description = "Successful";
                response.Data = request;
            }
            else
            {
                response.Code = "99";
                response.Description = "An error occurred, Please try again later";
            }
            return response;
        }

        //public async Task<APIResponse<int>> DeleteProduct(int productId)
        //{
        //    var response = new APIResponse<int>();
        //    var result = await service.DeleteProduct(productId);

        //    if (result == 1)
        //    {
        //        response.Code = "00";
        //        response.Description = "Successful";
        //        response.Data = productId;
        //    }
        //    else
        //    {
        //        response.Code = "99";
        //        response.Description = "An error occurred, Please try again later";
        //    }
        //    return response;
        //}
    }
}