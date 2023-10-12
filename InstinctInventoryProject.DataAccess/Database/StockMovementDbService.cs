using Dapper;
using InstinctInventoryProject.Domain.Models;
using InstinctInventoryProject.Domain.Response;
using InstinctInventoryProject.Domain.Utilities;
using System.Data;

namespace InstinctInventoryProject.DataAccess.Database
{
    public class StockMovementDbService
    {
        private readonly IDbConnection _connection;

        public StockMovementDbService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CreateStockMovement(StockMovement request)
        {
            try
            {
                var query = "[InsertInto_StockMovement]";
                var param = new
                {
                    ProductId = request.ProductId,
                    FromUnitId = request.FromUnitId,
                    ToUnitId = request.ToUnitId,
                    QuantityMoved = request.QuantityMoved,
                    MovementDate = request.MovementDate,
                    Reason = request.Reason,
                    CreatedBy = request.CreatedBy
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> UpdateStockMovement(StockMovement request)
        {
            try
            {
                var query = "[UpdateStockMovement]";
                var param = new
                {
                    MovementId = request.MovementId,
                    ProductId = request.ProductId,
                    FromUnitId = request.FromUnitId,
                    ToUnitId = request.ToUnitId,
                    QuantityMoved = request.QuantityMoved,
                    MovementDate = request.MovementDate,
                    Reason = request.Reason,
                    ModifiedBy = request.ModifiedBy
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<APIListResponse3<StockMovement>> GetStockMovementsByProductId(int productId, int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<StockMovement>();
            try
            {
                var query = "[GetStockMovementsByProductId]";
                var param = new { ProductId = productId, PageNumber = pageNumber, PageSize = pageSize };
                var result = await _connection.QueryAsync<StockMovement>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<StockMovement>.ToPagedList(result, pageNumber, pageSize);
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

        public async Task<APIListResponse3<StockMovement>> GetStockMovementsByUnitId(int unitId, int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<StockMovement>();
            try
            {
                var query = "[GetStockMovementsByUnitId]";
                var param = new { UnitId = unitId, PageNumber = pageNumber, PageSize = pageSize };
                var result = await _connection.QueryAsync<StockMovement>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<StockMovement>.ToPagedList(result, pageNumber, pageSize);
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

        public async Task<StockMovement> GetStockMovementByMovementId(int movementId)
        {
            StockMovement stockMovement = new StockMovement();
            try
            {
                var query = "[GetStockMovementByMovementId]";
                var param = new { MovementId = movementId };
                return await _connection.QueryFirstOrDefaultAsync<StockMovement>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Sequence contains no elements")
                    return stockMovement;
            }
            return null;
        }

        public async Task<APIListResponse3<StockMovement>> GetAllStockMovements(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<StockMovement>();
            try
            {
                var query = "[GetAllStockMovements]";
                var param = new { PageNumber = pageNumber, PageSize = pageSize };
                var result = await _connection.QueryAsync<StockMovement>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<StockMovement>.ToPagedList(result, pageNumber, pageSize);
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
    }
}