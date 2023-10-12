using AutoMapper;
using InstinctInventoryProject.BusinessLogic.Interface;
using InstinctInventoryProject.Domain.Dtos.Unit;
using InstinctInventoryProject.Domain.Models;
using InstinctInventoryProject.Domain.Response;
using Newtonsoft.Json;
using System.Data;

namespace InstinctInventoryProject.BusinessLogic.Respository
{
    public class UnitRepo : IUnit
    {
        private readonly IDbConnection _connection;
        private readonly DataAccess.Database.UnitDbService service;
        private readonly IMapper _mapper;

        public UnitRepo(IDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
            service = new DataAccess.Database.UnitDbService(connection);
        }

        public async Task<APIResponse<CreateUnitDto>> CreateUnit(CreateUnitDto request)
        {
            var response = new APIResponse<CreateUnitDto>();
            var model = _mapper.Map<Unit>(request);
            var result = await service.CreateUnit(model);

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

        public async Task<APIListResponse3<Unit>> GetUnits(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Unit>();
            var result = await service.GetUnits(pageNumber, pageSize);
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

        public async Task<APIResponse<Unit>> GetSingleUnit(int unitId)
        {
            var response = new APIResponse<Unit>();
            var result = await service.GetUnit(unitId);

            if (result != null)
            {
                if (result.UnitId == 0)
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

        public async Task<APIResponse<UpdateUnitDto>> UpdateUnit(UpdateUnitDto request)
        {
            var response = new APIResponse<UpdateUnitDto>();
            var model = _mapper.Map<Unit>(request);
            var result = await service.UpdateUnit(model);

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
    }
}