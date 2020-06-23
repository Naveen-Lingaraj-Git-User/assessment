using Assessment.Core.DTOs;
using Assessment.Core.Enums;
using Assessment.Core.Interfaces;
using Assessment.Core.ViewModels;
using Assessment.Core.ViewModels.Extensions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Assessment.Core.Services
{
    public class PromotionEngineService : BaseService, IPromotionEngineService
    {
        public PromotionEngineViewModel ProcessCheckout(IList<CartItemViewModel> cartItems, PromotionType[] promotionTypes)
        {
            // 1. Apply promotions
            cartItems = cartItems.ApplyPromotion(promotionTypes);

            // 2. Return processed items
            return new PromotionEngineViewModel
            {
                Result = new PromotionEngineDTO { CartItems = Using<IMapper>().Map<IList<CartItemDTO>>(cartItems.Select(x => x.Result)), TotalOrderValue = cartItems.Select(x => x.Result.Price).Sum() }
            };
        }
    }
}
