using ProdStore;
using ProdStore.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
   public class OrderItemCollectionTests
    {
       
        private static Order CreateTestOrder()
        {
            return new Order(new OrderDto
            {
                Id = 1,
                Items = new List<OrderItemDto>
                {
                    new OrderItemDto { ProductId = 1, Price = 10m, Count = 3},
                    new OrderItemDto { ProductId = 2, Price = 100m, Count = 5},
                }
            });
        }
        [Fact]
        public void Get_WithExistingItem_ReturnsItem()
        {
            var order = CreateTestOrder();

            var orderItem = order.items.Get(1);

            Assert.Equal(3, orderItem.Count);
        }
        [Fact]
        public void Get_WithNonExistingItem_ThrowsInvalidOperationException()
        {
            var order = CreateTestOrder();

            Assert.Throws<InvalidOperationException>(() =>
            {
                order.items.Get(100);
            });
        }
        [Fact]
        public void Add_WithExistingItem_ThrowInvalidOperationException()
        {
            var order = CreateTestOrder();

            Assert.Throws<InvalidOperationException>(() =>
            {
                order.items.Add(1, 10m, 10);
            });
        }

        [Fact]
        public void Add_WithNewItem_SetsCount()
        {
            var order = CreateTestOrder();

            order.items.Add(4, 30m, 10);

            Assert.Equal(10, order.items.Get(4).Count);
        }

        [Fact]
        public void Remove_WithExistingItem_RemovesItem()
        {
            var order = CreateTestOrder();

            order.items.Remove(1);

            Assert.Collection(order.items,
                              item => Assert.Equal(2, item.ProductId));
        }

        [Fact]
        public void Remove_WithNonExistingItem_ThrowsInvalidOperationException()
        {
            var order = CreateTestOrder();

            Assert.Throws<InvalidOperationException>(() =>
            {
                order.items.Remove(100);
            });
        }
    }
}
