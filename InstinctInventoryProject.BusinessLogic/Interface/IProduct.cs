namespace InstinctInventoryProject.BusinessLogic.Interface
{
    internal class IProduct
    {
        Task<APIListResponse3<Product>> GetProducts(int pageNumber, int pageSize);

        Task<APIResponse<Product>> GetSingleProduct(int productId);

        Task<APIResponse<CreateProductDto>> CreateProduct(CreateProductDto request);

        Task<APIResponse<UpdateProductDto>> UpdateProduct(UpdateProductDto request);

        //Task<APIResponse<int>> DeleteProduct(int productId);
    }
}