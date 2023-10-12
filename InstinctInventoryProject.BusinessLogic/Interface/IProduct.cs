using InstinctInventoryProject.Domain.Dtos.Product;
using InstinctInventoryProject.Domain.Models;
using InstinctInventoryProject.Domain.Response;

namespace InstinctInventoryProject.BusinessLogic.Interface
{
    public interface IProduct
    {
        Task<APIListResponse3<Product>> GetProducts(int pageNumber, int pageSize);

        Task<APIResponse<Product>> GetSingleProduct(int productId);

        Task<APIResponse<CreateProductDto>> CreateProduct(CreateProductDto request);

        Task<APIResponse<UpdateProductDto>> UpdateProduct(UpdateProductDto request);

        //Task<APIResponse<int>> DeleteProduct(int productId);
    }
}