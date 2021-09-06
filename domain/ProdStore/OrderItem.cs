using ProdStore.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdStore
{
    public class OrderItem
    {
        private readonly OrderItemDto dto;
        public int ProductId => dto.ProductId;
       public int Count
        {
            get { return dto.Count; }
            set
            {
                ThrowIsInvalidCount(value);
                dto.Count = value;
            }
        }
        public decimal Price
        {
            get => dto.Price;
            set => dto.Price = value;
        }
        internal OrderItem(OrderItemDto dto)
        {
            this.dto = dto;
        }
        private static void ThrowIsInvalidCount(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count is less then 1");
        }
        public static class DtoFactory
        {
            public static OrderItemDto Create(OrderDto order,int productId,decimal price,int count)
            {
                if (order == null)
                    throw new ArgumentNullException(nameof(order));
                ThrowIsInvalidCount(count);
                return new OrderItemDto
                {
                    ProductId = productId,
                    Price = price,
                    Count = count,
                    Order = order,
                };
            }
        }
        public static class Mapper
        {
            public static OrderItem Map(OrderItemDto dto) => new OrderItem(dto);
            public static OrderItemDto Map(OrderItem domain) => domain.dto;
        }
    }
}
