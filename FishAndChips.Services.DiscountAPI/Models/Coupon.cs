using System.ComponentModel.DataAnnotations;

namespace FishAndChips.Services.DiscountAPI.Models
{
    // Represents a discount coupon in the system
    public class Coupon
    {
        // Primary key for the Coupon entity
        [Key]
        public int CouponID { get; set; }

        // Code for the coupon, required field
        [Required]
        public string? CouponCode { get; set; }

        // Discount amount provided by the coupon, required field
        [Required]
        public double DiscountAmount { get; set; }

        // Minimum amount required to apply the coupon
        public int MinAmount { get; set; }
    }
}

