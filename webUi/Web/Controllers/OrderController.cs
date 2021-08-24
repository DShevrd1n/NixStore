using Microsoft.AspNetCore.Mvc;
using ProdStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository ordereRepository;
        public OrderController(IProductRepository productRepository, IOrderRepository ordereRepository)
        {
            this.productRepository = productRepository;
            this.ordereRepository = ordereRepository;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
               var  order = ordereRepository.GetById(cart.OrderId);
                OrderModel orderModel = Map(order);
                return View(orderModel);
            }
            return View("Empty");
        }
        public IActionResult AddItem(int id)
        {
           
            Order order;
            Cart cart;
            if (HttpContext.Session.TryGetCart(out cart))
            {
                order = ordereRepository.GetById(cart.OrderId);
            }
            else
            {
                order = ordereRepository.Create();
                cart = new Cart(order.Id);
            }
            var product = productRepository.GetById(id);
            order.AddItem(product, 1);
            ordereRepository.Update(order);
            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;
            HttpContext.Session.Set(cart);
            return RedirectToAction("Index", "Product", new {  id });

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
    }
}
