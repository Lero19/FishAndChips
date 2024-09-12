using FishAndChips.Services.DiscountAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FishAndChips.Services.CouponAPI.Data
{
    // Represents the database context for the application
    public class ApplicationDbContext : DbContext
    {
        // Constructor to initialize the DbContext with options
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // DbSet representing the Coupons table in the database
        public DbSet<Coupon> Coupons { get; set; }

        // Overriding the OnModelCreating method to configure the model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Calling the base class's OnModelCreating method to ensure any configurations in the base class are applied
            base.OnModelCreating(modelBuilder);

            // Seeding the Coupon entity with initial data
            modelBuilder.Entity<Coupon>().HasData(
            new Coupon
            {
                CouponID = 1,
                CouponCode = "TestOFF",
                DiscountAmount = 10,
                MinAmount = 100,
            },
            new Coupon
            {
                CouponID = 2,
                CouponCode = "Save20",
                DiscountAmount = 20,
                MinAmount = 200,
            },
            new Coupon
            {
                CouponID = 3,
                CouponCode = "HalfPrice",
                DiscountAmount = 50,
                MinAmount = 500,
            },
            new Coupon
            {
                CouponID = 4,
                CouponCode = "FreeShip",
                DiscountAmount = 15,
                MinAmount = 150,
            },
            new Coupon
            {
                CouponID = 5,
                CouponCode = "Welcome10",
                DiscountAmount = 10,
                MinAmount = 50,
            });

        }

    }
}