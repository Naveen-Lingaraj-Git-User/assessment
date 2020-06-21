using Assessment.Core.DTOs;
using Assessment.Core.Interfaces;
using Assessment.Core.ViewModels;
using AutoMapper;
using System.Collections.Generic;

namespace Assessment.Core.Services
{
    public class PromotionEngineService : BaseService, IPromotionEngineService
    {
        public PromotionEngineViewModel CaculateTotalOrderValue(IList<CartItemViewModel> cartItems)
        {
            return new PromotionEngineViewModel
            {
                Result = new PromotionEngineDTO
                {
                    CartItems = Using<IMapper>().Map<IList<CartItemDTO>>(cartItems),
                    TotalOrderValue = 100
                }
            };
        }
    }
}
