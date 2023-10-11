using Dapper;
using InstinctInventoryProject.Domain.Models;
using InstinctInventoryProject.Domain.Response;
using InstinctInventoryProject.Domain.Utilities;
using System.Data;

namespace InstinctInventoryProject.DataAccess.Database
{
    public class ProductDbService
    {
        private readonly IDbConnection _connection;

        public ProductDbService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CreateProduct(Product request)
        {
            try
            {
                var query = @"[InsertInto_Product]";
                var param = new
                {
                    ProductName = request.ProductName,
                    ProductDescription = request.ProductDescription,
                    UnitPrice = request.UnitPrice,
                    SupplierId = request.SupplierId,
                    StockQuantity = request.StockQuantity,
                    CreatedBy = request.CreatedBy
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<Product> GetProduct(int productId)
        {
            Product product = new Product();
            try
            {
                var query = @"[GetProductById]";
                var param = new { ProductId = productId };
                return await _connection.QueryFirstOrDefaultAsync<Product>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Sequence contains no elements")
                    return product;
            }
            return null;
        }

        public async Task<APIListResponse3<Product>> GetProducts(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Product>();
            try
            {
                var query = @"[GetAllProducts]";
                var param = new { PageNumber = pageNumber, PageSize = pageSize };
                var result = await _connection.QueryAsync<Product>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<Product>.ToPagedList(result, pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Sequence contains no elements")
                {
                    response.Code = "01";
                }
            }
            return response;
        }

        public async Task<int> UpdateProduct(Product request)
        {
            try
            {
                var query = @"[UpdateProduct]";
                var param = new
                {
                    ProductId = request.ProductId,
                    ProductName = request.ProductName,
                    ProductDescription = request.ProductDescription,
                    UnitPrice = request.UnitPrice,
                    SupplierId = request.SupplierId,
                    StockQuantity = request.StockQuantity,
                    ModifiedBy = request.ModifiedBy
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //public async Task<int> DeleteProduct(int productId)
        //{
        //    try
        //    {
        //        var query = "DeleteProduct";
        //        var param = new { ProductId = productId };
        //        return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
        //    }
        //    catch (Exception ex)
        //    {
        //        return 0;
        //    }
        //}

    }
}
