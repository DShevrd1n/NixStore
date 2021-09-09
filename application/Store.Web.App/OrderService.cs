using Microsoft.AspNetCore.Http;
using ProdStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<(bool hasValue,OrderModel model)> TryGetModelAsync()
        {
            var (hasValue, order) = await TryGetOrderAsync();
            if (hasValue)
                return (true, await MapAsync(order));
            return (false, null);
        }
        internal async Task<OrderModel> MapAsync(Order order)
        {
            var products = await GetProductsAsync(order);
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
        private async Task<IEnumerable<Product>> GetProductsAsync(Order order)
        {
            var productIds = order.items.Select(item => item.ProductId);
            return await productRepository.GetAllByIdsAsync(productIds);
        }
        public async Task<OrderModel> AddProductAsync(int productId, int count)
        {
            if (count < 1)
                throw new InvalidOperationException(nameof(count));
            var (hasValue, order) =await TryGetOrderAsync();
            if (!hasValue)
                order = await orderRepository.CreateAsync();

            await AddOrUpdateProductAsync(order, productId, count);
            UpdateSession(order);

            return await MapAsync(order);
        }
        internal async Task AddOrUpdateProductAsync(Order order, int productId, int count)
        {
            var book = await productRepository.GetByIdAsync(productId);
            if (order.items.TryGet(productId, out OrderItem orderItem))
                orderItem.Count += count;
            else
                order.items.Add(book.Id, book.Price, count);
           await orderRepository.UpdateAsync(order);
        }
        internal void UpdateSession(Order order)
        {
            var cart = new Cart(order.Id, order.TotalCount, order.TotalPrice);
            Session.Set(cart);
        }
        public async Task<OrderModel> UpdateProductAsync(int productId, int count)
        {
            var order = await GetOrderAsync();
            order.items.Get(productId).Count = count;

            await orderRepository.UpdateAsync(order);
            UpdateSession(order);

            return await MapAsync(order);
        }
        public async Task<OrderModel> FinishOrderAsync(string cellPhone, string adress, string paymentType)
        {
            var order = await GetOrderAsync();
            
            order.Adress = adress; order.CellPhone = cellPhone; order.PaymentType = paymentType;
            await orderRepository.UpdateAsync(order);
            Session.RemoveCart();
            return await MapAsync(order);
        }
        public async Task<OrderModel> RemoveProductAsync(int productId)
        {
            var order = await GetOrderAsync();
            order.items.Remove(productId);

            await orderRepository.UpdateAsync(order);
            UpdateSession(order);

            return await MapAsync (order);
        }
        public async Task<Order> GetOrderAsync()
        {
            var (hasValue, order) = await TryGetOrderAsync();
            if (hasValue)
                return order;
            throw new InvalidOperationException("Empty session.");
        }
        internal async  Task<(bool hasValue, Order order)> TryGetOrderAsync()
        {
            if (Session.TryGetCart(out Cart cart))
            {
               var  order = await orderRepository.GetByIdAsync(cart.OrderId);
                return (true, order);
            }
            
            return (false,null);
        }
    }
}
