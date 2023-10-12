using InstinctInventoryProject.Domain.Dtos.Unit;
using InstinctInventoryProject.Domain.Models;
using InstinctInventoryProject.Domain.Response;

namespace InstinctInventoryProject.BusinessLogic.Interface
{
    public interface IUnit
    {
        Task<APIListResponse3<Unit>> GetUnits(int pageNumber, int pageSize);

        Task<APIResponse<Unit>> GetSingleUnit(int unitId);

        Task<APIResponse<CreateUnitDto>> CreateUnit(CreateUnitDto request);

        Task<APIResponse<UpdateUnitDto>> UpdateUnit(UpdateUnitDto request);
    }
}