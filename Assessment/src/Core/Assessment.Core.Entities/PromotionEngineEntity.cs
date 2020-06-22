using System;
using System.Collections.Generic;

namespace Assessment.Core.Entities
{
    public class PromotionEngineEntity
    {
        public IList<CartItemEntity> CartItems { get; set; }
        public int TotalOrderValue { get; set; }
    }
}
