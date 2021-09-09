using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdStore;
using Store.Web.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ProductService productService;
        public SearchController(ProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IActionResult> Index(string query)
        {
            var products = await productService.GetAllByQueryAsync(query);
            return View("Index", products);
        }


    }
}
