using Dapper;
using InstinctInventoryProject.Domain.Models;
using InstinctInventoryProject.Domain.Response;
using InstinctInventoryProject.Domain.Utilities;
using System.Data;

namespace InstinctInventoryProject.DataAccess.Database
{
    public class UnitDbService
    {
        private readonly IDbConnection _connection;

        public UnitDbService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CreateUnit(Unit unit)
        {
            try
            {
                var query = "[InsertInto_Unit]";
                var param = new
                {
                    UnitName = unit.UnitName,
                    Location = unit.Location,
                    CreatedBy = unit.CreatedBy
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<Unit> GetUnit(int unitId)
        {
            Unit unit = new Unit();
            try
            {
                var query = @"[GetUnitById]";
                var param = new { UnitId = unitId };
                return await _connection.QueryFirstOrDefaultAsync<Unit>(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Sequence contains no elements")
                    return unit;
            }
            return null;
        }

        public async Task<APIListResponse3<Unit>> GetUnits(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Unit>();
            try
            {
                var query = "[GetAllUnits]";
                var param = new { PageNumber = pageNumber, PageSize = pageSize };
                var result = await _connection.QueryAsync<Unit>(query, param, commandType: CommandType.StoredProcedure);
                response.Data = PagedList<Unit>.ToPagedList(result, pageNumber, pageSize);
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

        public async Task<int> UpdateUnit(Unit unit)
        {
            try
            {
                var query = "[UpdateUnit]";
                var param = new
                {
                    UnitId = unit.UnitId,
                    UnitName = unit.UnitName,
                    Location = unit.Location,
                    ModifiedBy = unit.ModifiedBy
                };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> DeleteUnit(int unitId)
        {
            try
            {
                var query = "[DeleteUnit]";
                var param = new { UnitId = unitId };
                return await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}