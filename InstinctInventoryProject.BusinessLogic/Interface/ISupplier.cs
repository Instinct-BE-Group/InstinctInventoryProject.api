using InstinctInventoryProject.Domain.Dtos.Supplier;
using InstinctInventoryProject.Domain.Models;
using InstinctInventoryProject.Domain.Response;

namespace InstinctInventoryProject.BusinessLogic.Interface
{
    public interface ISupplier
    {
        Task<APIListResponse3<Supplier>> GetSuppliers(int pageNumber, int pageSize);

        Task<APIResponse<Supplier>> GetSingleSupplier(int supplierId);

        Task<APIResponse<CreateSupplierDto>> CreateSupplier(CreateSupplierDto request);

        Task<APIResponse<UpdateSupplierDto>> UpdateSupplier(UpdateSupplierDto request);
    }
}