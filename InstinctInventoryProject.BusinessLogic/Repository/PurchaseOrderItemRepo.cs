using AutoMapper;
using InstinctInventoryProject.BusinessLogic.Interface;
using InstinctInventoryProject.DataAccess.Database;
using InstinctInventoryProject.Domain.Dtos.PurchaseOrderItem;
using InstinctInventoryProject.Domain.Models;
using InstinctInventoryProject.Domain.Response;
using Newtonsoft.Json;
using System.Data;

namespace InstinctInventoryProject.BusinessLogic.Repository
{
    public class PurchaseOrderItemRepo : IPurchaseOrderItems
    {
        private readonly IDbConnection _connection;
        private readonly PurchaseOrderItemsDbService service;
        private readonly IMapper _mapper;

        public PurchaseOrderItemRepo(IDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
            service = new PurchaseOrderItemsDbService(connection);
        }

        public async Task<APIResponse<CreatePurchaseOrderItemDto>> CreatePurchaseOrderItem(CreatePurchaseOrderItemDto request)
        {
            var response = new APIResponse<CreatePurchaseOrderItemDto>();
            var model = _mapper.Map<PurchaseOrderItem>(request);
            var result = await service.CreatePurchaseOrderItem(model);

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

        public async Task<APIListResponse3<PurchaseOrderItem>> GetPurchaseOrderItem(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<PurchaseOrderItem>();
            var result = await service.GetPurchasedItem(pageNumber, pageSize);
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

        public async Task<APIResponse<PurchaseOrderItem>> SinglePurchaseOrderItem(int Id)
        {
            var response = new APIResponse<PurchaseOrderItem>();
            var result = await service.SinglePurchase(Id);

            if (result != null)
            {
                if (result.OrderItemId == 0)
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

        public async Task<APIResponse<UpdatePurchaseOrderItemDto>> UpdatePurchaseOrderItem(UpdatePurchaseOrderItemDto request)
        {
            var response = new APIResponse<UpdatePurchaseOrderItemDto>();
            var model = _mapper.Map<PurchaseOrderItem>(request);
            var result = await service.UpdatePurchaseOrderItems(model);

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