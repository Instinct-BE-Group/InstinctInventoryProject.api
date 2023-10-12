using InstinctInventoryProject.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InstinctInventoryProject.DataAccess
{
    public interface IAppDbContext
    {
        DbSet<CurrentStock> CurrentStocks { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        DbSet<StockMovement> StockMovements { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
        DbSet<Unit> Units { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserRole> UserRoles { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}