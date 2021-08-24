using ProdStore;
using System;
using Xunit;
namespace Tests
{
    public class OrderTests
    {
        [Fact]
        public void Order_WithNullItems_ThrowsEx()
        {
            Assert.Throws<ArgumentNullException>(() => new Order(1, null));

        }
        [Fact]
        public void TotalCount_WithEmptyItems_ReturnZero()
        {
            var order = new Order(1, new OrderItem[0]);
            Assert.Equal(0, order.TotalCount);
        }
        [Fact]
        public void TotalPrice_WithEmptyItems_ReturnZero()
        {
            var order = new Order(1, new OrderItem[0]);
            Assert.Equal(0m, order.TotalPrice);
        }
        [Fact]
        public void TotalCount_WithNonEmptyItems_CalculateTotalCount()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1,2,10m),
                new OrderItem(2,3,5m),
            });
            Assert.Equal(2 + 3, order.TotalCount);
        }
        [Fact]
        public void TotalPrice_WithNonEmptyItems_CalculateTotalPrice()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1,2,10m),
                new OrderItem(2,3,5m),
            });
            Assert.Equal(2*10m + 3*5m, order.TotalPrice);
        }
    }
}
