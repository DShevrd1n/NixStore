using Microsoft.AspNetCore.Mvc;
using ProdStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository ordereRepository;
        public CartController(IProductRepository productRepository, IOrderRepository ordereRepository)
        {
            this.productRepository = productRepository;
            this.ordereRepository = ordereRepository;
        }
        public IActionResult Add(int id)
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
    }
}
