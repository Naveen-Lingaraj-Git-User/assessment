using Assessment.Core.DTOs;
using Assessment.Core.Enums;
using Assessment.Core.Interfaces;
using Assessment.Core.ViewModels;
using NUnit.Framework;
using System.Collections.Generic;

namespace Assessment.Core.UnitTests
{
    using static TestStartUp;
    public class Tests
    {
        [Test]
        public void TestScenarioA()
        {
            // Arrange
            var cartItems = new List<CartItemViewModel>
            {
                new CartItemViewModel
                {
                    Result = new CartItemDTO { Item = Items.A, ItemCount = 1 }
                },
                new CartItemViewModel
                {
                    Result = new CartItemDTO { Item = Items.B, ItemCount = 1 }
                },
                new CartItemViewModel
                {
                    Result = new CartItemDTO { Item = Items.C, ItemCount = 1 }
                }
            };

            // Act
            var promotionTypes = new PromotionType[] { PromotionType.Promotion3A, PromotionType.Promotion2B, PromotionType.PromotionCD };
            var result = Using<IPromotionEngineService>().ProcessCheckout(cartItems, promotionTypes).Result;
            
            // Assert
            Assert.AreEqual(100, result.TotalOrderValue);
        }
        
        [Test]
        public void TestScenarioB()
        {
            // Arrange
            var cartItems = new List<CartItemViewModel>
            {
                new CartItemViewModel
                {
                    Result = new CartItemDTO { Item = Items.A, ItemCount = 5 }
                },
                new CartItemViewModel
                {
                    Result = new CartItemDTO { Item = Items.B, ItemCount = 5 }
                },
                new CartItemViewModel
                {
                    Result = new CartItemDTO { Item = Items.C, ItemCount = 1 }
                }
            };

            // Act
            var promotionTypes = new PromotionType[] { PromotionType.Promotion3A, PromotionType.Promotion2B, PromotionType.PromotionCD };
            var result = Using<IPromotionEngineService>().ProcessCheckout(cartItems, promotionTypes).Result;

            // Assert
            Assert.AreEqual(370, result.TotalOrderValue);
        }
        
        [Test]
        public void TestScenarioC()
        {
            // Arrange
            var cartItems = new List<CartItemViewModel>
            {
                new CartItemViewModel
                {
                    Result = new CartItemDTO { Item = Items.A, ItemCount = 3 }
                },
                new CartItemViewModel
                {
                    Result = new CartItemDTO { Item = Items.B, ItemCount = 5 }
                },
                new CartItemViewModel
                {
                    Result = new CartItemDTO { Item = Items.C, ItemCount = 1 }
                },
                new CartItemViewModel
                {
                    Result = new CartItemDTO { Item = Items.D, ItemCount = 1 }
                }
            };

            // Act
            var promotionTypes = new PromotionType[] { PromotionType.Promotion3A, PromotionType.Promotion2B, PromotionType.PromotionCD };
            var result = Using<IPromotionEngineService>().ProcessCheckout(cartItems, promotionTypes).Result;

            // Assert
            Assert.AreEqual(280, result.TotalOrderValue);
        }
    }
}