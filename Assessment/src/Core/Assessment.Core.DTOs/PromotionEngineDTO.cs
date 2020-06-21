using Assessment.Core.Entities;
using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assessment.Core.DTOs
{
    [AutoMap(typeof(PromotionEngineEntity), ReverseMap = true)]
    public class PromotionEngineDTO
    {
        public IList<CartItemDTO> CartItems { get; set; }
        public int TotalOrderValue { get; set; }
    }
}
