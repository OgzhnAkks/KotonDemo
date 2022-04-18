using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccessLibrary.DataAccess;

public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions dbContextOptions) : base(dbContextOptions) {}

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Biling> Bilings { get; set; }
    public DbSet<Taxe> Taxes { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Customer> Customer { get; set; }
}
