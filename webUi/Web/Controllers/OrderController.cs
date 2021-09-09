using Microsoft.AspNetCore.Mvc;
using ProdStore;
using System.Linq;
using Web.Models;
using System;
using Store.Web.App;
using Microsoft.AspNetCore.Authorization;
using ProdStore.Data;
using System.Threading.Tasks;
using Store.Data.EF;

namespace Web.Controllers
{
    [Authorize(Roles = "admin,user")]
    public class OrderController : Controller
    {
        private readonly OrderService orderService;
        
        private StoreDbContext db;
        private readonly EmailService service;
        public OrderController(OrderService orderService, StoreDbContext context, EmailService service)
        {
            this.orderService = orderService;
            db = context;
            this.service = service;
            
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (orderService.TryGetModel(out OrderModel model))
                return View(model);
            return View("Empty");
            
        }
        public IActionResult In()
        {
            return View("ConfirmOrder");

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
        public IActionResult Finish(string cellPhone, string adress, string paymentType,string email)
        {
            orderService.FinishOrder(cellPhone,adress,paymentType);
            service.Send(email);
            
            return View("Empty");
        }
        


    }
}
