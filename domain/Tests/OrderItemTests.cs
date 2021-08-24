using ProdStore;
using System;
using Xunit;

namespace Tests
{
   public  class OrderItemTests
    {
        [Fact]
        public void OrderItem_WithZeroCount_ThrowsEx()
        {
            int count = 0;
            Assert.Throws<ArgumentOutOfRangeException>(() => new OrderItem(1, count, 0m));
        }
        [Fact]
        public void OrderItem_WithNegativeCount_ThrowsEx()
        {
            int count = -1;
            Assert.Throws<ArgumentOutOfRangeException>(() => new OrderItem(1, count, 0m));
        }
        [Fact]
        public void OrderItem_WithValidCount_SetsCount()
        {
            var orderItem = new OrderItem(1, 1, 1m);
            Assert.Equal(1, orderItem.ProductId);
            Assert.Equal(1, orderItem.Count);
            Assert.Equal(1m, orderItem.Price);

        }
    }
}
