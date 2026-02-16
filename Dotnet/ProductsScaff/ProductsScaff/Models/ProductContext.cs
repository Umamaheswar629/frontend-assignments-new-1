using Microsoft.EntityFrameworkCore;

namespace ProductsScaff.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
                : base(options)
        { }
        public DbSet<ProductsItem> ProductsItems { get; set; } = null!;
    }
}
