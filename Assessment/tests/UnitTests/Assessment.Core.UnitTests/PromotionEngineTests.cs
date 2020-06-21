using Assessment.Core.DTOs;
using Assessment.Core.Interfaces;
using Assessment.Core.ViewModels;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Assessment.Core.UnitTests
{
    using static TestStartUp;
    public class Tests
    {
        [Test]
        public void Test1()
        {
            // Arrange
            var cartItems = new List<CartItemViewModel>();
            cartItems.Add(new CartItemViewModel { Result = new CartItemDTO { Item = 'A', ItemCount = 1 } });
            cartItems.Add(new CartItemViewModel { Result = new CartItemDTO { Item = 'B', ItemCount = 2 } });
            cartItems.Add(new CartItemViewModel { Result = new CartItemDTO { Item = 'C', ItemCount = 3 } });

            Assert.AreEqual(Using<IPromotionEngineService>().CaculateTotalOrderValue(cartItems).Result.TotalOrderValue, 100);
        }
    }
}