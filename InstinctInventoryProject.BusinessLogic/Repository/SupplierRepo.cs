using AutoMapper;
using InstinctInventoryProject.BusinessLogic.Interface;
using InstinctInventoryProject.Domain.Dtos.Supplier;
using InstinctInventoryProject.Domain.Models;
using InstinctInventoryProject.Domain.Response;
using Newtonsoft.Json;
using System.Data;

namespace InstinctInventoryProject.BusinessLogic.Respository
{
    public class SupplierRepo : ISupplier
    {
        private readonly IDbConnection _connection;
        private readonly DataAccess.Database.SupplierDbService service;
        private readonly IMapper _mapper;

        public SupplierRepo(IDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
            service = new DataAccess.Database.SupplierDbService(connection);
        }

        public async Task<APIResponse<CreateSupplierDto>> CreateSupplier(CreateSupplierDto request)
        {
            var response = new APIResponse<CreateSupplierDto>();
            var model = _mapper.Map<Supplier>(request);
            var result = await service.CreateSupplier(model);

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

        public async Task<APIListResponse3<Supplier>> GetSuppliers(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Supplier>();
            var result = await service.GetSuppliers(pageNumber, pageSize);
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

        public async Task<APIResponse<Supplier>> GetSingleSupplier(int supplierId)
        {
            var response = new APIResponse<Supplier>();
            var result = await service.GetSupplier(supplierId);

            if (result != null)
            {
                if (result.SupplierId == 0)
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

        public async Task<APIResponse<UpdateSupplierDto>> UpdateSupplier(UpdateSupplierDto request)
        {
            var response = new APIResponse<UpdateSupplierDto>();
            var model = _mapper.Map<Supplier>(request);
            var result = await service.UpdateSupplier(model);

            if (result == 1)
            {
                response.Code = "00";
                response.Description = "Successful";
                response.Data = request;
            }
            else
            {
                response.Code = "99";
                response.Description = "An error occurred. Please try again later";
            }
            return response;
        }
    }
}