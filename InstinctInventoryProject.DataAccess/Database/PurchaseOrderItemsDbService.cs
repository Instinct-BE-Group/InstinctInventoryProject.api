using Dapper;
using InstinctInventoryProject.Domain.Models;
using InstinctInventoryProject.Domain.Response;
using InstinctInventoryProject.Domain.Utilities;
using System.Data;

namespace InstinctInventoryProject.DataAccess.Database
{
    public class PurchaseOrderItemsDbService
    {
        private readonly IDbConnection _connection;

        public PurchaseOrderItemsDbService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CreatePurchaseOrderItem(PurchaseOrderItem request)
        {
            try
            {
                var query = @"[InsertInto_PurchaseOrderItems]";
                var param = new
                {
                    OrderItemId = request.OrderItemId,
                    PurchaseOrderId = request.PurchaseOrderId,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                    UnitPrice = request.UnitPrice,
                    TotalAmount = request.TotalAmount,
                    CreatedBy = request.CreatedBy,
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<PurchaseOrderItem> SinglePurchase(int id)
        {
            PurchaseOrderItem purchases = new PurchaseOrderItem();
            try
            {
                var query = @"[GetPurchaseOrderItems]";
                var param = new
                {
                    OrderItemId = id
                };
                return await _connection.QueryFirstAsync<PurchaseOrderItem>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Sequence contain no elements"))
                    return purchases;
            }
            return null;
        }

        public async Task<APIListResponse3<PurchaseOrderItem>> GetPurchasedItem(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<PurchaseOrderItem>();
            try
            {
                var query = @"[GetAllPurchaseOrderItems]";
                var param = new { pageNumber = pageNumber, pageSize = pageSize };
                var result = await _connection.QueryAsync<PurchaseOrderItem>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<PurchaseOrderItem>.ToPagedList(result, pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Sequence contatins no elements"))
                {
                    response.Code = "01";
                }
            }
            return response;
        }

        public async Task<int> UpdatePurchaseOrderItems(PurchaseOrderItem request)
        {
            try
            {
                var query = @"[Update_PurchaseOrderItems]";
                var param = new
                {
                    OrderItemId = request.OrderItemId,
                    PurchaseOrderId = request.PurchaseOrderId,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                    UnitPrice = request.UnitPrice,
                    TotalAmount = request.TotalAmount,
                    ModifiedBy = request.ModifiedBy,
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}