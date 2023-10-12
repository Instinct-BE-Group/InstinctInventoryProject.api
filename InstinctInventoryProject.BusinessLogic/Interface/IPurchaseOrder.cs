using InstinctInventoryProject.Domain.Dtos.PurchaseOrder;
using InstinctInventoryProject.Domain.Models;
using InstinctInventoryProject.Domain.Response;

namespace InstinctInventoryProject.BusinessLogic.Interface
{
    public interface IPurchaseOrder
    {
        Task<APIListResponse3<PurchaseOrder>> GetPurchases(int pageNumber, int pageSize);

        Task<APIResponse<PurchaseOrder>> SinglePurchase(int productId);

        Task<APIResponse<CreatePurchaseOrderDto>> CreatePurchaseOrder(CreatePurchaseOrderDto request);

        Task<APIResponse<UpdatePurchaseOrderDto>> UpdatePurchaseOrder(UpdatePurchaseOrderDto request);
    }
}