using ProdStore;
using ProdStore.Data;
using System;
using Xunit;

namespace Tests
{
    public class OrderItemTests
    {
        [Fact]
        public void OrderItem_WithZeroCount_ThrowsEx()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int count = 0;
                OrderItem.DtoFactory.Create(new OrderDto(), 1, 10m, count);
            });
        }
        [Fact]
        public void OrderItem_WithNegativeCount_ThrowsEx()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int count = -1;
                OrderItem.DtoFactory.Create(new OrderDto(), 1, 10m, count);
            });
        }
        [Fact]
        public void OrderItem_WithValidCount_SetsCount()
        {
            var orderItem = OrderItem.DtoFactory.Create(new OrderDto(), 1, 10m, 2);

            Assert.Equal(1, orderItem.ProductId);
            Assert.Equal(10m, orderItem.Price);
            Assert.Equal(2, orderItem.Count);

        }
        [Fact]
        public void Count_IsNegativeValue_ThrowsEx()
        {
            var orderItemDto = OrderItem.DtoFactory.Create(new OrderDto(), 1, 10m, 30);
            var orderItem = OrderItem.Mapper.Map(orderItemDto);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                orderItem.Count = -1;
            });
        }
        [Fact]
        public void Count_IsZeroValue_ThrowsEx()
        {
            var orderItemDto = OrderItem.DtoFactory.Create(new OrderDto(), 1, 10m, 30);
            var orderItem = OrderItem.Mapper.Map(orderItemDto);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                orderItem.Count = 0;
            });
        }
        [Fact]
        public void Count_IsPositiveValue_SetsValue()
        {
            var orderItemDto = OrderItem.DtoFactory.Create(new OrderDto(), 1, 10m, 30);
            var orderItem = OrderItem.Mapper.Map(orderItemDto);

            orderItem.Count = 10;

            Assert.Equal(10, orderItem.Count);
        }
    }
}
