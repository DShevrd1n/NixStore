using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ProdStore.Data;

namespace ProdStore
{
   public  class Order
    {
        private readonly OrderDto dto;
        public int Id => dto.Id;
        public string CellPhone 
        {
            get => dto.CellPhone;
            set => dto.CellPhone = value;
        }
        public string Adress 
        {
            get => dto.Adress;
            set => dto.Adress = value;
        }
        public string PaymentType 
        {
            get => dto.PaymentType;
            set => dto.PaymentType = value;
        }
        public OrderItemCollection items { get; }
       
        public Order(OrderDto dto)
        {
            this.dto = dto;
            items = new OrderItemCollection(dto);
        }
        public int TotalCount
        {
            get { return items.Sum(item => item.Count); }
        }
        public decimal TotalPrice
        {
            get { return items.Sum(item => item.Price * item.Count); }
        }
        public static class DtoFactory
        {
            public static OrderDto Create() => new OrderDto();
        }
        public static class Mapper
        {
            public static Order Map(OrderDto dto) => new Order(dto);
            public static OrderDto Map(Order domain) => domain.dto;
        }
    }
}
