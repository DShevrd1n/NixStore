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
        private readonly EmailService service;
        public OrderController(OrderService orderService, EmailService service)
        {
            this.orderService = orderService;
            this.service = service;
            
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var (hasValue, model) = await orderService.TryGetModelAsync();
            if (hasValue)
                return View(model);
            return View("Empty");
            
        }
        public IActionResult Confirm()
        {
            return View("ConfirmOrder");

        }

        [HttpPost]
        public async Task<IActionResult> AddItemAsync(int id, int count = 1)
        {
            await orderService.AddProductAsync(id, count);
            return RedirectToAction("Index", "Product", new { id });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateItemAsync(int id, int count)
        {
            var model = await orderService.UpdateProductAsync(id, count);
            return View("Index", model);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> RemoveItem(int id)
        {

            var model = await orderService.RemoveProductAsync(id);
            return View("Index", model);
        }
        public async Task<IActionResult> FinishAsync(string cellPhone, string adress, string paymentType,string email)
        {
            await orderService.FinishOrderAsync(cellPhone,adress,paymentType);
            service.Send(email);
            
            return View("Empty");
        }
        


    }
}
