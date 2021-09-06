﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.App
{
    public class Cart
    {
        public int OrderId { get; }
        public int TotalCount { get;  }
        public decimal TotalPrice { get;  }
        public Cart (int orderId,int totalCount,decimal totalPrice)
        {
            OrderId = orderId;
            TotalCount = totalCount;
            TotalPrice = totalPrice;
        }
    }
}