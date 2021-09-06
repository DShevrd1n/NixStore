using System;
using System.Collections.Generic;
using System.Text;

namespace ProdStore.Data
{
    public class OrderDto
    {
        public int Id { get; set; }
        public IList<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }
}
