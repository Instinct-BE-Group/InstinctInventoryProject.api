using AutoMapper;
using InstinctInventoryProject.BusinessLogic.Interface;
using InstinctInventoryProject.DataAccess.Database;
using InstinctInventoryProject.Domain.Dtos.StockMovement;
using InstinctInventoryProject.Domain.Models;
using InstinctInventoryProject.Domain.Response;
using Newtonsoft.Json;
using System.Data;

namespace InstinctInventoryProject.BusinessLogic.Respository
{
    public class StockMovementRepo : IStockMovement
    {
        private readonly IDbConnection _connection;
        private readonly StockMovementDbService _service;
        private readonly IMapper _mapper;

        public StockMovementRepo(IDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
            _service = new StockMovementDbService(connection);
        }

        public async Task<APIResponse<CreateStockMovementDto>> CreateStockMovement(CreateStockMovementDto request)
        {
            var response = new APIResponse<CreateStockMovementDto>();
            var model = _mapper.Map<StockMovement>(request);
            var result = await _service.CreateStockMovement(model);

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

        public async Task<APIResponse<UpdateStockMovementDto>> UpdateStockMovement(UpdateStockMovementDto request)
        {
            var response = new APIResponse<UpdateStockMovementDto>();
            var model = _mapper.Map<StockMovement>(request);
            var result = await _service.UpdateStockMovement(model);

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

        public async Task<APIListResponse3<StockMovement>> GetStockMovementsByProductId(int productId, int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<StockMovement>();
            var result = await _service.GetStockMovementsByProductId(productId, pageNumber, pageSize);
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

        public async Task<APIListResponse3<StockMovement>> GetStockMovementsByUnitId(int unitId, int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<StockMovement>();
            var result = await _service.GetStockMovementsByUnitId(unitId, pageNumber, pageSize);
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

        public async Task<APIResponse<StockMovement>> GetStockMovementByMovementId(int movementId)
        {
            var response = new APIResponse<StockMovement>();
            var result = await _service.GetStockMovementByMovementId(movementId);

            if (result != null)
            {
                if (result.MovementId == 0)
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

        public async Task<APIListResponse3<StockMovement>> GetAllStockMovements(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<StockMovement>();
            var result = await _service.GetAllStockMovements(pageNumber, pageSize);
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
    }
}