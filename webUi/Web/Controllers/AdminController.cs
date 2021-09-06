using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdStore;
using ProdStore.Data;
using Store.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private StoreDbContext db;
        public AdminController(StoreDbContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Products.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                ProductDto product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                    return View(product);
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                ProductDto product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                    return View(product);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductDto product)
        {
            db.Products.Update(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                ProductDto product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                    return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                ProductDto product = new ProductDto { Id = id.Value };
                db.Entry(product).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
