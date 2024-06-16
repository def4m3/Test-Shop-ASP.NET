using Orders.Models;
using Microsoft.EntityFrameworkCore;

namespace Orders.Interfaces
{
    public interface IShopDbContext
    {
        DbSet<Order> Orders { get; set; }
        
        DbSet<Product> Products { get; set; }

        DbSet<OrderProduct> OrderProducts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
