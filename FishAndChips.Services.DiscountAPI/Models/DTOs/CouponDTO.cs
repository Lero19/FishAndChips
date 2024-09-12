namespace FishAndChips.Services.CouponAPI.Models.DTOs
{
    // Data Transfer Object for Coupon
    public class CouponDTO
    {
        // Unique identifier for the coupon
        public int CouponID { get; set; }

        // Code for the coupon, can be null
        public string? CouponCode { get; set; }

        // Discount amount provided by the coupon
        public double DiscountAmount { get; set; }

        // Minimum amount required to apply the coupon
        public int MinAmount { get; set; }
    }
}

