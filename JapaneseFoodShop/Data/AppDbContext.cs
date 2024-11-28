using JapaneseFoodShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace JapaneseFoodShop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public AppDbContext() { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var adminRole = new Role
            {
                Id = Guid.NewGuid().ToString(),
                Name = "admin",
            };
            modelBuilder.Entity<Role>().HasData(adminRole);
            modelBuilder.Entity<User>().HasOne(p => p.Role).WithMany().HasForeignKey(p => p.RoleId);
            modelBuilder.Entity<Employee>().HasOne(p => p.User).WithOne().HasForeignKey<Employee>(p => p.UserId);
            modelBuilder.Entity<Customer>().HasOne(p => p.User).WithOne().HasForeignKey<Customer>(p => p.UserId);
            modelBuilder.Entity<RolePermission>().HasKey(p => new { p.RoleId, p.PermissionId });
            modelBuilder.Entity<RolePermission>().HasOne(p => p.Role).WithMany().HasForeignKey(p => p.RoleId);
            modelBuilder.Entity<RolePermission>().HasOne(p => p.Permission).WithMany().HasForeignKey(p => p.PermissionId);

        }
    }
}
