using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task3.Models;

namespace Task3.Models.CodeFirst
{
    public class CafeteriaEmployeesDbContext : IdentityDbContext
    {
        public CafeteriaEmployeesDbContext(DbContextOptions<CafeteriaEmployeesDbContext> options)
            : base(options)
        {
        }

       
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<SupplyRequest> SupplyRequests { get; set; }
        public DbSet<RequestItem> RequestItems { get; set; }
    


protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

    }
}

