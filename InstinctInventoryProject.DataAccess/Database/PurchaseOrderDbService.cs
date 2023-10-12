using Dapper;
using InstinctInventoryProject.Domain.Models;
using InstinctInventoryProject.Domain.Response;
using InstinctInventoryProject.Domain.Utilities;
using System.Data;

namespace InstinctInventoryProject.DataAccess.Database
{
    public class PurchaseOrderDbService
    {
        private readonly IDbConnection _connection;

        public PurchaseOrderDbService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CreatePurchaseOrder(PurchaseOrder request)
        {
            try
            {
                var query = @"[InsertInto_PurchaseOrders]";
                var param = new
                {
                    OrderId = request.OrderId,
                    OrderDate = request.OrderDate,
                    SupplierId = request.SupplierId,
                    TotalAmount = request.TotalAmount,
                    OrderStatus = request.OrderStatus,
                    DeliveryDate = request.DeliveryDate,
                    RequestedBy = request.RequestedBy,
                    UnitId = request.UnitId,
                    ApprovedBy = request.ApprovedBy,
                    CreatedBy = request.CreatedBy,
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<PurchaseOrder> SinglePurchase(int id)
        {
            PurchaseOrder purchases = new PurchaseOrder();
            try
            {
                var query = @"[GetPurchaseOrder]";
                var param = new
                {
                    OrderId = id
                };
                return await _connection.QueryFirstAsync<PurchaseOrder>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Sequence contain no elements"))
                    return purchases;
            }
            return null;
        }

        public async Task<APIListResponse3<PurchaseOrder>> GetPurchases(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<PurchaseOrder>();
            try
            {
                var query = @"[GetAllPurchaseOrder]";
                var param = new { pageNumber = pageNumber, pageSize = pageSize };
                var result = await _connection.QueryAsync<PurchaseOrder>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<PurchaseOrder>.ToPagedList(result, pageNumber, pageSize);
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

        public async Task<int> UpdatePurchaseOrder(PurchaseOrder request)
        {
            try
            {
                var query = @"[Update_PurchaseOrder]";
                var param = new
                {
                    OrderId = request.OrderId,
                    OrderDate = request.OrderDate,
                    SupplierId = request.SupplierId,
                    TotalAmount = request.TotalAmount,
                    OrderStatus = request.OrderStatus,
                    DeliveryDate = request.DeliveryDate,
                    RequestedBy = request.RequestedBy,
                    UnitId = request.UnitId,
                    ApprovedBy = request.ApprovedBy,
                    ModifiedBy = request.ModifiedBy
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