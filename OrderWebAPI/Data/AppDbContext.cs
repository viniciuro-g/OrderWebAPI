using Microsoft.EntityFrameworkCore;
using OrderWebAPI.Models.Entities;

namespace BudgetWebAPI.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {

                entity.HasKey(o => o.Id);

                entity.Property(o => o.Description)
                .HasMaxLength(500);

                entity.Property(o => o.CreatedAt)
                .IsRequired();

                entity.Property(o => o.CustomerId)
                .IsRequired();

                entity.Property(o => o.Status)
                .IsRequired()
                .HasConversion<int>();

                entity.HasOne(o => o.Customer)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.Ignore(o => o.TotalValue);
                entity.Ignore(o => o.ItemsQuantity);
            });


            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(c => c.Address)
                .HasMaxLength(250);

                entity.Property(c => c.Email)
                .HasMaxLength(100);


                //relacionamento
                entity.HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(i => i.Id);

                entity.Property(i => i.Quantity)
                .IsRequired();

                entity.Property(i => i.Description)
                .IsRequired()
                .HasMaxLength(200);

                entity.Property(i => i.UnitPrice)
                .IsRequired();

                entity.HasOne(i => i.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(i => i.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.Ignore(i => i.TotalPrice);
            });

        }
    }
}
