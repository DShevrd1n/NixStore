using ProdStore;
using System;
using Xunit;

namespace Tests
{
   //public  class OrderItemTests
   // {
   //     [Fact]
   //     public void OrderItem_WithZeroCount_ThrowsEx()
   //     {
   //         int count = 0;
   //         Assert.Throws<ArgumentOutOfRangeException>(() => new OrderItem(1, count, 0m));
   //     }
   //     [Fact]
   //     public void OrderItem_WithNegativeCount_ThrowsEx()
   //     {
   //         int count = -1;
   //         Assert.Throws<ArgumentOutOfRangeException>(() => new OrderItem(1, count, 0m));
   //     }
   //     [Fact]
   //     public void OrderItem_WithValidCount_SetsCount()
   //     {
   //         var orderItem = new OrderItem(1, 1, 1m);
   //         Assert.Equal(1, orderItem.ProductId);
   //         Assert.Equal(1, orderItem.Count);
   //         Assert.Equal(1m, orderItem.Price);

   //     }
   //     [Fact]
   //     public void Count_IsNegativeValue_ThrowsEx()
   //     {
   //         var orderItem = new OrderItem(0, 5, 0m);
   //         Assert.Throws<ArgumentOutOfRangeException>(() => { orderItem.Count = -1; });
   //     }
   //     [Fact]
   //     public void Count_IsZeroValue_ThrowsEx()
   //     {
   //         var orderItem = new OrderItem(0, 5, 0m);
   //         Assert.Throws<ArgumentOutOfRangeException>(() => { orderItem.Count = 0; });
   //     }
   //     [Fact]
   //     public void Count_IsPositiveValue_SetsValue()
   //     {
   //         var orderItem = new OrderItem(0, 5, 0m);
   //         orderItem.Count = 10;
   //         Assert.Equal(10, orderItem.Count);
   //     }
   // }
}
