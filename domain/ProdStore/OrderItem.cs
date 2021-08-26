using System;
using System.Collections.Generic;
using System.Text;

namespace ProdStore
{
    public class OrderItem
    {
        public int ProductId { get; }
        private int count;
        public int Count {
            get { return count; }
            set
            {
                ThrowIsInvalidCount(value);
                count = value;
            }
        }
        public decimal Price { get; }
        public OrderItem(int prductId,int count, decimal price)
        {
            ThrowIsInvalidCount(count);
            ProductId = prductId;
            Count = count;
            Price = price;
        }

        private static void ThrowIsInvalidCount(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count is less then 1");
        }
    }
}
