using Assessment.Core.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assessment.Core.Interfaces
{
    public interface IPromotionEngineService
    {
        PromotionEngineViewModel ProcessOrder(IList<CartItemViewModel> cartItems);
    }
}
