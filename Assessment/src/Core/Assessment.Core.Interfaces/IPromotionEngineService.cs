using Assessment.Core.Enums;
using Assessment.Core.ViewModels;
using System.Collections.Generic;

namespace Assessment.Core.Interfaces
{
    public interface IPromotionEngineService
    {
        PromotionEngineViewModel ProcessCheckout(IList<CartItemViewModel> cartItems, PromotionType[] promotionTypes);
    }
}
