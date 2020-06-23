using Assessment.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Assessment.Core.ViewModels.Extensions
{
    public static class CartItemViewModelExtensions
    {
        public static IList<CartItemViewModel> ApplyPromotion(this IList<CartItemViewModel> cartItems, PromotionType[] promotionTypes)
        {
            foreach (var promotionType in promotionTypes)
            {
                switch (promotionType)
                {
                    case PromotionType.Promotion3A:
                        cartItems.ApplyPromotion3A();
                        break;
                    case PromotionType.Promotion2B:
                        cartItems.ApplyPromotion2B();
                        break;
                    case PromotionType.PromotionCD:
                        cartItems.ApplyPromotionCD();
                        break;
                }
            }
            return cartItems;
        }

        public static IList<CartItemViewModel> ApplyPromotion3A(this IList<CartItemViewModel> cartItems)
        {
            foreach (var cartItem in cartItems)
            {
                if (cartItem.Result.Item == Items.A)
                {
                    if (cartItem.Result.ItemCount >= 3)
                    {
                        var itemCount = (int)Math.Floor((decimal)(cartItem.Result.ItemCount % 3));
                        var itemComboCount = (int)Math.Floor((decimal)(cartItem.Result.ItemCount / 3));
                        cartItem.Result.Price = (itemComboCount * (int)PromotionType.Promotion3A) + (itemCount * (int)Items.A);
                    }
                    else
                    {
                        cartItem.Result.Price = (int)Items.A;
                    }
                }
            }
            return cartItems;
        }

        public static IList<CartItemViewModel> ApplyPromotion2B(this IList<CartItemViewModel> cartItems)
        {
            foreach (var cartItem in cartItems)
            {
                if (cartItem.Result.Item == Items.B)
                {
                    if (cartItem.Result.ItemCount >= 2)
                    {
                        var itemCount = (int)Math.Floor((decimal)(cartItem.Result.ItemCount % 2));
                        var itemComboCount = (int)Math.Floor((decimal)(cartItem.Result.ItemCount / 2));
                        cartItem.Result.Price = (itemComboCount * (int)PromotionType.Promotion2B) + (itemCount * (int)Items.B);
                    }
                    else
                    {
                        cartItem.Result.Price = (int)Items.B;
                    }
                }
            }
            return cartItems;
        }

        public static IList<CartItemViewModel> ApplyPromotionCD(this IList<CartItemViewModel> cartItems)
        {
            var cartItemsCD = new List<CartItemViewModel>();
            foreach (var cartItem in cartItems)
            {
                if (cartItem.Result.Item == Items.C || cartItem.Result.Item == Items.D)
                {
                    cartItemsCD.Add(cartItem);
                }
            }
            foreach (var cartItem in cartItems)
            {
                if (cartItemsCD.Count >= 2)
                {
                    var itemCount = 2;
                    var itemComboCount = cartItemsCD[1].Result.ItemCount % 1;
                    if (cartItemsCD[1].Result.Item == Items.C)
                    {
                        cartItemsCD[1].Result.Price = (itemComboCount * (int)PromotionType.PromotionCD) + (itemCount * (int)Items.C);
                        cartItemsCD[0].Result.Price = 0;
                    }
                    else if (cartItemsCD[1].Result.Item == Items.D)
                    {
                        cartItemsCD[1].Result.Price = (itemComboCount * (int)PromotionType.PromotionCD) + (itemCount * (int)Items.D);
                        cartItemsCD[0].Result.Price = 0;
                    }
                    var itemWithNoPrice = cartItemsCD.Select(x => x.Result).Where(x => x.Price == 0).FirstOrDefault();
                    var itemWithPrice = cartItemsCD.Select(x => x.Result).Where(x => x.Price != 0).FirstOrDefault();
                    if (itemWithNoPrice != null && cartItem.Result.Item == itemWithNoPrice.Item)
                    {
                        cartItem.Result.Price = itemWithNoPrice.Price;
                    }
                    if (itemWithPrice != null && cartItem.Result.Item == itemWithPrice.Item)
                    {
                        cartItem.Result.Price = itemWithPrice.Price;
                    }
                }
                else
                {
                    if (cartItem.Result.Item == Items.C)
                    {
                        cartItem.Result.Price = (int)Items.C;
                    }
                    else if (cartItem.Result.Item == Items.D)
                    {
                        cartItem.Result.Price = (int)Items.D;
                    }
                }
            }
            return cartItems;
        }
    }
}
