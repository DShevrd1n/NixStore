using Microsoft.AspNetCore.Mvc;
using ProdStore;
using System.Linq;
using Web.Models;
using System;
using Store.Web.App;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize(Roles = "admin,user")]
    public class OrderController : Controller
    {
        private readonly OrderService orderService;
        public OrderController(OrderService orderService)
        {
            this.orderService = orderService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (orderService.TryGetModel(out OrderModel model))
                return View(model);
            return View("Empty");
            
        }

        [HttpPost]
        public IActionResult AddItem(int id, int count = 1)
        {
            orderService.AddProduct(id, count);
            return RedirectToAction("Index", "Product", new { id });
        }

        [HttpPost]
        public IActionResult UpdateItem(int id, int count)
        {
            var model = orderService.UpdateProduct(id, count);
            return View("Index", model);
        }
        
        
        [HttpPost]
        public IActionResult RemoveItem(int id)
        {

            var model = orderService.RemoveProduct(id);
            return View("Index", model);
        }
       
        //public ViewResult Checkout( ShippingDetails shippingDetails)
        //{
        //    if (HttpContext.Session.TryGetCart(out Cart cart))
        //    {
        //        var order = orderRepository.GetById(cart.OrderId);
        //        return View(new ShippingDetails());
        //    }
        //    return View("Empty");

        //}
    }
}
