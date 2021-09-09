using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProdStore.Data;
using Store.Data.EF;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private StoreDbContext db;
        public HomeController(ILogger<HomeController> logger, StoreDbContext context)
        {
            _logger = logger;
            db = context;
        }
       
        public async Task<IActionResult> Index(string name, string category, int page = 1, 
            SortState sortOrder = SortState.NameAsc)
        {
            
            int pageSize = 6;
            IQueryable<ProductDto> products = db.Products;
            if (!String.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category.Contains(category));
            }
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    products = products.OrderByDescending(s => s.Name);
                    break;
                case SortState.PriceAsc:
                    products = products.OrderBy(s => s.Price);
                    break;
                case SortState.PriceDesc:
                    products = products.OrderByDescending(s => s.Price);
                    break;
                default:
                    products = products.OrderBy(s => s.Name);
                    break;
            }
            var count = await products.CountAsync();
            var items = await products.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                ProductDtos = items,
                Category=category
            };

            return View(viewModel);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
