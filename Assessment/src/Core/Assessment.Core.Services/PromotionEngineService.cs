using Assessment.Core.DTOs;
using Assessment.Core.Interfaces;
using Assessment.Core.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessment.Core.Services
{
    public class PromotionEngineService : BaseService, IPromotionEngineService
    {
        public PromotionEngineViewModel ProcessCheckout(IList<CartItemViewModel> cartItems)
        {
            return new PromotionEngineViewModel
            {
                Result = new PromotionEngineDTO { CartItems = Using<IMapper>().Map<IList<CartItemDTO>>(cartItems.Select(x => x.Result)), TotalOrderValue = cartItems.Select(x => x.Result.Price).Sum() }
            };
        }
    }
}
