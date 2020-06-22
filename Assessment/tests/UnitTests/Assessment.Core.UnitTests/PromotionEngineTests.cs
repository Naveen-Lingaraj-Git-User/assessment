using Assessment.Core.DTOs;
using Assessment.Core.Interfaces;
using Assessment.Core.ViewModels;
using AutoMapper;
using NUnit.Framework;
using System.Collections;
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
                    Result = new CartItemDTO { Item = "A", ItemCount = 1 }
                },
                new CartItemViewModel
                {
                    Result = new CartItemDTO { Item = "B", ItemCount = 2 }
                },
                new CartItemViewModel
                {
                    Result = new CartItemDTO { Item = "C", ItemCount = 3 }
                }
            };

            // Assert
            Assert.AreEqual(Using<IPromotionEngineService>().ProcessOrder(cartItems).Result.TotalOrderValue, 0);
        }
    }
}