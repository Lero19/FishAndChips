using AutoMapper;
using FishAndChips.Services.CouponAPI.Models.DTOs;
using FishAndChips.Services.DiscountAPI.Models;

namespace FishAndChips.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration( config =>
            {
                config.CreateMap<CouponDTO, Coupon>();
                config.CreateMap<Coupon, CouponDTO>();
            });
            return mappingConfig;
        }
    }
}
