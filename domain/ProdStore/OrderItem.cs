using System;
using System.Collections.Generic;
using System.Text;

namespace ProdStore
{
    public class OrderItem
    {
        public int ProductId { get; }
        public int Count { get; }
        public decimal Price { get; }
        public OrderItem(int prductId,int count, decimal price)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count is less then 1");
            ProductId = prductId;
            Count = count;
            Price = price;
        }
    }
}
