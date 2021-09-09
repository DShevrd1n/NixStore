using Microsoft.AspNetCore.Http;
using ProdStore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Store.Web.App
{
    public class OrderService
    {
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        protected ISession Session => httpContextAccessor.HttpContext.Session;
        public OrderService(IProductRepository productRepository, IOrderRepository orderRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
            this.httpContextAccessor = httpContextAccessor;
        }
        public bool TryGetModel(out OrderModel model)
        {
            if (TryGetOrder(out Order order))
            {
                model = Map(order);
                return true;
            }
            model = null;
            return false;
        }
        
        internal OrderModel Map(Order order)
        {
            var products = GetProducts(order);
            var items = from item in order.items
                        join product in products on item.ProductId equals product.Id
                        select new OrderItemModel
                        {
                            ProductId = product.Id,
                            Name = product.Name,
                            Articul = product.Articul,
                            Price = item.Price,
                            Count = item.Count,

                        };
            return new OrderModel
            {
                Id = order.Id,
                Items = items.ToArray(),
                TotalCount = order.TotalCount,
                TotalPrice = order.TotalPrice,
            };
        }

        private IEnumerable<Product> GetProducts(Order order)
        {
            var productIds = order.items.Select(item => item.ProductId);
            return productRepository.GetAllByIds(productIds);
        }
        public OrderModel AddProduct(int productId, int count)
        {
            if (count < 1)
                throw new InvalidOperationException(nameof(count));
            if (!TryGetOrder(out Order order))
                order = orderRepository.Create();

            AddOrUpdateProduct(order, productId, count);
            UpdateSession(order);

            return Map(order);
        }
        internal void AddOrUpdateProduct(Order order, int productId, int count)
        {
            var book = productRepository.GetById(productId);
            if (order.items.TryGet(productId, out OrderItem orderItem))
                orderItem.Count += count;
            else
                order.items.Add(book.Id, book.Price, count);
            orderRepository.Update(order);
        }
        internal void UpdateSession(Order order)
        {
            var cart = new Cart(order.Id, order.TotalCount, order.TotalPrice);
            Session.Set(cart);
        }
        public OrderModel UpdateProduct(int productId, int count)
        {
            var order = GetOrder();
            order.items.Get(productId).Count = count;

            orderRepository.Update(order);
            UpdateSession(order);

            return Map(order);
        }

        public OrderModel RemoveProduct(int productId)
        {
            var order = GetOrder();
            order.items.Remove(productId);

            orderRepository.Update(order);
            UpdateSession(order);

            return Map(order);
        }
        public OrderModel FinishOrder(string cellPhone,string adress,string paymentType)
        {
           
            var order = GetOrder();
            order.Adress = adress;order.CellPhone = cellPhone;order.PaymentType=paymentType;
            orderRepository.Update(order);
            Session.RemoveCart();
            return Map(order);
            
        }

        public Order GetOrder()
        {
            if (TryGetOrder(out Order order))
                return order;

            throw new InvalidOperationException("Empty session.");
        }
        internal bool TryGetOrder(out Order order)
        {
            if (Session.TryGetCart(out Cart cart))
            {
                order = orderRepository.GetById(cart.OrderId);
                return true;
            }
            order = null;
            return false;

        }
    }
}
