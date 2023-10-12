using AutoMapper;
using InstinctInventoryProject.BusinessLogic.Repository;
using InstinctInventoryProject.Domain.Dtos.Product;
using InstinctInventoryProject.Domain.Dtos.PurchaseOrder;
using InstinctInventoryProject.Domain.Dtos.PurchaseOrderItem;
using InstinctInventoryProject.Domain.Dtos.StockMovement;
using InstinctInventoryProject.Domain.Dtos.Supplier;
using InstinctInventoryProject.Domain.Dtos.Unit;
using InstinctInventoryProject.Domain.Models;

namespace InstinctInventoryProject.api.Extentions
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Product, CreateProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<Product, UpdateProductDto>();
            CreateMap<UpdateProductDto, Product>();

            CreateMap<PurchaseOrder, CreatePurchaseOrderDto>();
            CreateMap<CreatePurchaseOrderDto, PurchaseOrder>();
            CreateMap<PurchaseOrder, UpdatePurchaseOrderDto>();
            CreateMap<UpdatePurchaseOrderDto, PurchaseOrder>();

            CreateMap<PurchaseOrderItem, CreatePurchaseOrderDto>();
            CreateMap<CreatePurchaseOrderItemDto, PurchaseOrderItem>();
            CreateMap<PurchaseOrderItem, UpdatePurchaseOrderItemDto>();
            CreateMap<UpdatePurchaseOrderItemDto, PurchaseOrderItem>();

            CreateMap<Supplier, CreateSupplierDto>();
            CreateMap<CreateSupplierDto, Supplier>();
            CreateMap<Supplier, UpdateSupplierDto>();
            CreateMap<UpdateSupplierDto, Supplier>();

            CreateMap<Unit, CreateUnitDto>();
            CreateMap<CreateUnitDto, Unit>();
            CreateMap<Unit, UpdateUnitDto>();
            CreateMap<UpdateUnitDto, Unit>();

            CreateMap<StockMovement, CreateStockMovementDto>();
            CreateMap<CreateStockMovementDto, StockMovement>();
            CreateMap<StockMovement, UpdateStockMovementDto>();
            CreateMap<UpdateStockMovementDto, StockMovement>();
        }
    }
}