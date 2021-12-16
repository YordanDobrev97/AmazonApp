using AmazonSystem.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AmazonSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<CreditCardPayment> CreditCardPayments { get; set; }

        public DbSet<PaypalPayment> PaypalPayments { get; set; }

        public DbSet<CashPayment> CashPayments { get; set; }

        public DbSet<Operator> Operators { get; set; }
    }
}
