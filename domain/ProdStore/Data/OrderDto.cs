using System;
using System.Collections.Generic;
using System.Text;

namespace ProdStore.Data
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string CellPhone { get; set; }
        public string Adress { get; set; }
        public string PaymentType { get; set; }
        public IList<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }
}
