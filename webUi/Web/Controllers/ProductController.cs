﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProdStore;
using Store.Web.App;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService productService;
        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index(int id)
        {
            var model = productService.GetById(id);
            return View(model);
        }
    }
}
