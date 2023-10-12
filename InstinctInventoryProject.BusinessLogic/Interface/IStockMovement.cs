using InstinctInventoryProject.Domain.Dtos.StockMovement;
using InstinctInventoryProject.Domain.Models;
using InstinctInventoryProject.Domain.Response;

namespace InstinctInventoryProject.BusinessLogic.Interface
{
    public interface IStockMovement
    {
        Task<APIResponse<CreateStockMovementDto>> CreateStockMovement(CreateStockMovementDto request);

        Task<APIResponse<UpdateStockMovementDto>> UpdateStockMovement(UpdateStockMovementDto request);

        Task<APIListResponse3<StockMovement>> GetStockMovementsByProductId(int productId, int pageNumber, int pageSize);

        Task<APIListResponse3<StockMovement>> GetStockMovementsByUnitId(int unitId, int pageNumber, int pageSize);

        Task<APIResponse<StockMovement>> GetStockMovementByMovementId(int movementId);

        Task<APIListResponse3<StockMovement>> GetAllStockMovements(int pageNumber, int pageSize);
    }
}