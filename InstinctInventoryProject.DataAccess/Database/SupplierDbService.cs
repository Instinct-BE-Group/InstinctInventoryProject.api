using Dapper;
using InstinctInventoryProject.Domain.Models;
using InstinctInventoryProject.Domain.Response;
using InstinctInventoryProject.Domain.Utilities;
using System.Data;

namespace InstinctInventoryProject.DataAccess.Database
{
    public class SupplierDbService
    {
        private readonly IDbConnection _connection;

        public SupplierDbService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CreateSupplier(Supplier request)
        {
            try
            {
                var query = @"[CreateSupplier]";
                var param = new
                {
                    SupplierName = request.SupplierName,
                    ContactInformation = request.ContactInformation,
                    CreatedBy = request.CreatedBy
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<Supplier> GetSupplier(int supplierId)
        {
            Supplier supplier = new Supplier();
            try
            {
                var query = @"[GetSupplierById]";
                var param = new { SupplierId = supplierId };
                return await _connection.QueryFirstOrDefaultAsync<Supplier>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Sequence contains no elements")
                    return supplier;
            }
            return null;
        }

        public async Task<APIListResponse3<Supplier>> GetSuppliers(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Supplier>();
            try
            {
                var query = @"[GetAllSuppliers]";
                var param = new { PageNumber = pageNumber, PageSize = pageSize };
                var result = await _connection.QueryAsync<Supplier>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<Supplier>.ToPagedList(result, pageNumber, pageSize);
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

        public async Task<int> UpdateSupplier(Supplier request)
        {
            try
            {
                var query = @"[UpdateSupplier]";
                var param = new
                {
                    SupplierId = request.SupplierId,
                    SupplierName = request.SupplierName,
                    ContactInformation = request.ContactInformation,
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