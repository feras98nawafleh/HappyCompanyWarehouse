using HappyCompanyWarehouse.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HappyCompanyWarehouse.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<WarehouseItem> WarehouseItems { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Role> Roles { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries<User>()
                .Where(e => e.State == EntityState.Deleted);

            foreach (var entry in entries)
            {
                if (entry.Entity.Id == 1)
                {
                    throw new InvalidOperationException("Cannot delete the admin user.");
                }
            }

            return base.SaveChanges(); 
        }
    }
}
