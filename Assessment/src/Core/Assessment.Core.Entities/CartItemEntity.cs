using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Core.Entities
{
    public class CartItemEntity
    {
        public int ItemCount { get; set; }
        public char Item { get; set; }
        public int Price { get; set; }
    }
}
