using AutoMapper;
using InstinctInventoryProject.BusinessLogic.Interface;
using InstinctInventoryProject.DataAccess.Database;
using InstinctInventoryProject.Domain.Dtos.PurchaseOrder;
using InstinctInventoryProject.Domain.Models;
using InstinctInventoryProject.Domain.Response;
using Newtonsoft.Json;
using System.Data;

namespace InstinctInventoryProject.BusinessLogic.Repository
{
    public class PurchaseOrderRepo : IPurchaseOrder
    {
        private readonly IDbConnection _connection;
        private readonly PurchaseOrderDbService service;
        private readonly IMapper _mapper;

        public PurchaseOrderRepo(IDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
            service = new PurchaseOrderDbService(connection);
        }

        public async Task<APIResponse<CreatePurchaseOrderDto>> CreatePurchaseOrder(CreatePurchaseOrderDto request)
        {
            var response = new APIResponse<CreatePurchaseOrderDto>();
            var model = _mapper.Map<PurchaseOrder>(request);
            var result = await service.CreatePurchaseOrder(model);

            if (result == 1)
            {
                response.Code = "00";
                response.Description = "Successful";
                response.Data = request;
            }
            else if (result == -1)
            {
                response.Code = "01";
                response.Description = "Record Already Exists";
            }
            else
            {
                response.Code = "99";
                response.Description = "An Error Occurred, Please try again later";
            }
            return response;
        }

        public async Task<APIListResponse3<PurchaseOrder>> GetPurchases(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<PurchaseOrder>();
            var result = await service.GetPurchases(pageNumber, pageSize);
            if (result != null)
            {
                if (result.Data.Count() > 0)
                {
                    var metadata = new
                    {
                        result.Data.TotalCount,
                        result.Data.PageSize,
                        result.Data.CurrentPage,
                        result.Data.TotalPages,
                        result.Data.HasNext,
                        result.Data.HasPrevious
                    };
                    response.PageInfo = JsonConvert.SerializeObject(metadata);
                    response.Code = "00";
                    response.Description = "Successful";
                    response.Data = result.Data;
                }
                else
                {
                    response.Code = "01";
                    response.Description = "No Record Found";
                }
            }
            else
            {
                response.Code = "99";
                response.Description = "An Error Occurred, Please try again later";
            }
            return response;
        }

        public async Task<APIResponse<PurchaseOrder>> SinglePurchase(int Id)
        {
            var response = new APIResponse<PurchaseOrder>();
            var result = await service.SinglePurchase(Id);

            if (result != null)
            {
                if (result.OrderId == 0)
                {
                    response.Code = "01";
                    response.Description = "No Record found";
                }
                else
                {
                    response.Code = "00";
                    response.Description = "Successful";
                    response.Data = result;
                }
            }
            else
            {
                response.Code = "01";
                response.Description = "No Record found";
            }
            return response;
        }

        public async Task<APIResponse<UpdatePurchaseOrderDto>> UpdatePurchaseOrder(UpdatePurchaseOrderDto request)
        {
            var response = new APIResponse<UpdatePurchaseOrderDto>();
            var model = _mapper.Map<PurchaseOrder>(request);
            var result = await service.UpdatePurchaseOrder(model);

            if (result == 1)
            {
                response.Code = "00";
                response.Description = "Successful";
                response.Data = request;
            }
            else
            {
                response.Code = "99";
                response.Description = "An error occured, Please try again later";
            }
            return response;
        }
    }
}