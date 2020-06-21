﻿using Assessment.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Core.DTOs
{
    [AutoMap(typeof(CartItemEntity), ReverseMap = true)]
    public class CartItemDTO
    {
        public int ItemCount { get; set; }
        public char Item { get; set; }
        public int Price { get; set; }
    }
}
