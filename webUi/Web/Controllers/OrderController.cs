using Microsoft.AspNetCore.Mvc;
using ProdStore;
using System.Linq;
using Web.Models;
using System;

namespace Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;
        public OrderController(IProductRepository productRepository, IOrderRepository ordereRepository)
        {
            this.productRepository = productRepository;
            this.orderRepository = ordereRepository;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
                var order = orderRepository.GetById(cart.OrderId);
                OrderModel orderModel = Map(order);
                return View(orderModel);
            }
            return View("Empty");
        }
        public IActionResult AddItem(int id, int count = 1)
        {
            (Order order, Cart cart) = GetOrderAndCart();
            var product = productRepository.GetById(id);
            order.AddOrUpdateItem(product, count);
            SaveOrderAndCart(order, cart);
            return RedirectToAction("Index", "Product", new { id });
        }
        [HttpPost]
        public IActionResult UpdateItem(int id, int count)
        {
            (Order order, Cart cart) = GetOrderAndCart();
            order.GetItem(id).Count = count;
            SaveOrderAndCart(order, cart);
            return RedirectToAction("Index", "Order");
        }
        private void SaveOrderAndCart(Order order, Cart cart)
        {
            orderRepository.Update(order);
            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;
            HttpContext.Session.Set(cart);
        }
        private (Order order, Cart cart) GetOrderAndCart()
        {
            Order order;
            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
                order = orderRepository.GetById(cart.OrderId);
            }
            else
            {
                order = orderRepository.Create();
                cart = new Cart(order.Id);
            }
            return (order, cart);
        }
        public IActionResult RemoveItem(int id)
        {

            (Order order, Cart cart) = GetOrderAndCart();
            order.RemoveItem(id);
            SaveOrderAndCart(order, cart);
            return RedirectToAction("Index", "Order");
        }
        private OrderModel Map(Order order)
        {
            var productIds = order.Items.Select(item => item.ProductId);
            var products = productRepository.GetAllByIds(productIds);
            var itemModels = from item in order.Items
                             join product in products on item.ProductId equals product.Id
                             select new OrderItemModel
                             {
                                 ProductId = product.Id,
                                 Name = product.Name,
                                 Articul = product.Artucil,
                                 Price = product.Price,
                                 Count = item.Count,
                             };
            return new OrderModel
            {
                Id = order.Id,
                Items = itemModels.ToArray(),
                TotalCount = order.TotalCount,
                TotalPrice = order.TotalPrice,
            };
        }
        public ViewResult Checkout( ShippingDetails shippingDetails)
        {
            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
                var order = orderRepository.GetById(cart.OrderId);
                return View(new ShippingDetails());
            }
            return View("Empty");

        }
    }
}
