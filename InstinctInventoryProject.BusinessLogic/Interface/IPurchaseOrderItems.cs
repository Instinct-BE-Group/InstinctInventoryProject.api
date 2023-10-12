using InstinctInventoryProject.BusinessLogic.Repository;
using InstinctInventoryProject.Domain.Dtos.PurchaseOrderItem;
using InstinctInventoryProject.Domain.Models;
using InstinctInventoryProject.Domain.Response;

namespace InstinctInventoryProject.BusinessLogic.Interface
{
    public interface IPurchaseOrderItems
    {
        Task<APIListResponse3<PurchaseOrderItem>> GetPurchaseOrderItem(int pageNumber, int pageSize);

        Task<APIResponse<PurchaseOrderItem>> SinglePurchaseOrderItem(int Id);

        Task<APIResponse<CreatePurchaseOrderItemDto>> CreatePurchaseOrderItem(CreatePurchaseOrderItemDto request);

        Task<APIResponse<UpdatePurchaseOrderItemDto>> UpdatePurchaseOrderItem(UpdatePurchaseOrderItemDto request);
    }
}